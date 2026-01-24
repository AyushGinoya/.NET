using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web.UI.WebControls;

public partial class InternalMarkCalculator1 : System.Web.UI.Page
{
    #region 11.1 initilization of variable
    string calculationMethod = "";
    int DistinctSubjects = 0;

    DataTable student;
    DataTable subject;
    DataTable collage;
    DataTable fieldTable;
    DataTable Result;
    #endregion

    #region 11.2 Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadData();
        if( !IsPostBack )
        {
            #region 11.2.1 load collage ddl 
            if( collage != null && collage.Rows.Count > 0 )
            {
                ddlCollegeId.DataSource = collage;
                ddlCollegeId.DataTextField = "CollageName";
                ddlCollegeId.DataValueField = "CollageId";
                ddlCollegeId.DataBind();
                ddlCollegeId.Items.Insert(0, new ListItem("Select College", "-1"));
            }
            #endregion

            #region 11.2.2 load semester and Year ddl
            if( fieldTable != null && fieldTable.Rows.Count > 0 )
            {
                List<string> Semester = fieldTable.AsEnumerable()
                                        .Select(row => row.Field<string>("Semester"))
                                        .Distinct()
                                        .OrderBy(sem => sem)
                                        .ToList();

                ddlSemesterID.DataSource = Semester;
                ddlSemesterID.DataBind();
                ddlSemesterID.Items.Insert(0, new ListItem("Select Semester", "-1"));

                List<string> Year = fieldTable.AsEnumerable()
                                              .Select(row => row.Field<string>("Year"))
                                              .Distinct()
                                              .OrderBy(year => year)
                                              .ToList();
                ddlYear.DataSource = Year;
                ddlYear.DataBind();
                ddlYear.Items.Insert(0, new ListItem("Select Year", "-1"));
            }
            #endregion

            #region 11.2.3 load branch ddl
            if( student != null && student.Rows.Count > 0 )
            {
                List<string> branch = student.AsEnumerable()
                                             .Select(row => row.Field<string>("BranchID"))
                                             .Distinct()
                                             .OrderBy(BranchID => BranchID)
                                             .ToList();

                ddlBranch.DataSource = branch;
                ddlBranch.DataBind();

                ddlBranch.Items.Insert(0, new ListItem("Select Branch", "-1"));

            }
            #endregion
        }
    }
    #endregion

    #region 11.3 Load CSV Data
    public static DataTable LoadCsvData(string csvFilePath, string name)
    {
        DataTable dt = new DataTable(name);
        try
        {
            string[] csvData = File.ReadAllLines(csvFilePath);

            if( csvData.Length > 0 )
            {
                string[] columnHeaders = csvData[0].Split(',');

                foreach( var header in columnHeaders )
                {
                    dt.Columns.Add(header);
                }

                for( int i = 1; i < csvData.Length; i++ )
                {
                    string[] rowData = csvData[i].Split(',');

                    DataRow row = dt.NewRow();

                    for( int j = 0; j < rowData.Length; j++ )
                    {
                        row[j] = rowData[j];
                    }

                    dt.Rows.Add(row);
                }
            }
        }
        catch( Exception ex )
        {
            Console.WriteLine("Error reading CSV file: " + ex.Message);
        }

        return dt;
    }
    #endregion

    #region 11.4 Load DataTable
    private void LoadData()
    {
        Result = GetResultTable();

        //fieldTable = LoadCsvData(Server.MapPath("~/student_data - student_data.csv"), "FieldWeightage");
        fieldTable = LoadCsvData(Server.MapPath("~/FieldWeightage - Sheet1 (1).csv"), "FieldWeightage");
        student = LoadCsvData(Server.MapPath("~/Student - Sheet1 (1).csv"), "Student");
        subject = LoadCsvData(Server.MapPath("~/Subject .csv"), "Subject");
        collage = LoadCsvData(Server.MapPath("~/Collage.csv"), "Collage");

        gvFieldWeightage.DataSource = fieldTable;
        gvFieldWeightage.DataBind();

        gvStudent.DataSource = student;
        gvStudent.DataBind();

        gvSubject.DataSource = subject;
        gvSubject.DataBind();

        gvCollage.DataSource = collage;
        gvCollage.DataBind();
    }
    #endregion

    #region 11.5 Calculate Button clicked
    protected void btnCalculate_Click(object sender, EventArgs e)
    {
        string calculationMethod = txtCalculationMethod.Text.Trim();

        if( !ValidateSelections(out int selectedCollegeId, out int selectedSemester, out int selectedYear) ) return;

        try
        {
            //Inner join on student and field table
            var joinedData = GetJoinedData(selectedCollegeId, selectedSemester, selectedYear);
            if( !joinedData.Any() )
            {
                lblResult.Text = "No data found for the selected college.";
                return;
            }

            //Get student marks from joindata
            var studentMarks = GetStudentMarks(joinedData);
            CalculateMarksForStudents(joinedData, studentMarks, calculationMethod);
            gvSubjectMarks.DataSource = Result;
            gvSubjectMarks.DataBind();
        }
        catch( Exception ex )
        {
            lblResult.Text = $"Error processing data: {ex.Message}";
        }
    }
    #endregion

    #region 11.6 Evaluate Dynamic Expression
    private decimal EvaluateDynamicExpression(string expression)
    {
        try
        {
            DataTable dataTable = new DataTable();
            object result = dataTable.Compute(expression, "");
            return Convert.ToDecimal(result);
        }
        catch( Exception ex )
        {
            throw new Exception($"Invalid expression: {expression}. Details: {ex.Message}");
        }
    }
    #endregion

    #region 11.7 Validate Student Data
    private bool ValidateStudentData(int StudentId, string studentName, int subjectId, int year, int semester, out string errorMessage)
    {
        bool isValid = true;
        errorMessage = string.Empty;

        if( StudentId <= 0 )
        {
            isValid = false;
            errorMessage += "Invalid StudentId: must be greater than 0.\n";
        }

        if( string.IsNullOrWhiteSpace(studentName) )
        {
            isValid = false;
            errorMessage += "Invalid StudentName: cannot be null, empty, or whitespace.\n";
        }

        if( subjectId <= 0 )
        {
            isValid = false;
            errorMessage += "Invalid SubjectId: must be greater than 0.\n";
        }

        if( year <= 0 )
        {
            isValid = false;
            errorMessage += "Invalid Year: must be greater than 0.\n";
        }

        if( semester <= 0 )
        {
            isValid = false;
            errorMessage += "Invalid Semester: must be greater than 0.\n";
        }

        return isValid;
    }
    #endregion

    #region 11.8 Validate ValidateSelections
    private bool ValidateSelections(out int collegeId, out int semester, out int year)
    {
        collegeId = semester = year = 0;

        if( string.IsNullOrEmpty(txtCalculationMethod.Text.Trim()) )
        {
            lblResult.Text = "Please provide a calculation formula.";
            return false;
        }

        if( !int.TryParse(ddlCollegeId.SelectedValue, out collegeId) || collegeId == -1 )
        {
            lblResult.Text = "Invalid CollegeId selected.";
            return false;
        }

        if( !int.TryParse(ddlSemesterID.SelectedValue, out semester) || semester == -1 )
        {
            lblResult.Text = "Invalid Semester selected.";
            return false;
        }

        if( !int.TryParse(ddlYear.SelectedValue, out year) || year == -1 )
        {
            lblResult.Text = "Invalid Year selected.";
            return false;
        }
        return true;
    }
    #endregion

    #region 11.9 GetJoinedData
    private IEnumerable<dynamic> GetJoinedData(int collegeId, int semester, int year)
    {
        return from std in student.AsEnumerable()
               join field in fieldTable.AsEnumerable()
               on std.Field<string>("StudentId") equals field.Field<string>("StudentId")
               where field.Field<string>("CollageId") == collegeId.ToString()
                  && field.Field<string>("Semester") == semester.ToString()
                  && field.Field<string>("Year") == year.ToString()
               select new
               {
                   StudentId = Convert.ToInt32(std.Field<string>("StudentId")),
                   SubjectId = Convert.ToInt32(field.Field<string>("SubjectId")),
                   StudentName = std.Field<string>("StudentName"),
                   CollageId = Convert.ToInt32(field.Field<string>("CollageId")),
                   FieldName = field.Field<string>("FieldName"),
                   Marks = Convert.ToDecimal(field.Field<string>("Marks")),
                   Semester = Convert.ToInt32(field.Field<string>("Semester")),
                   Year = Convert.ToInt32(field.Field<string>("Year"))
               };
    }
    #endregion

    #region 11.10 GetStudentMarks
    private Dictionary<int, Dictionary<int, Dictionary<string, decimal>>> GetStudentMarks(IEnumerable<dynamic> joinedData)
    {
        var studentMarks = new Dictionary<int, Dictionary<int, Dictionary<string, decimal>>>();

        foreach( var record in joinedData )
        {
            //Student exist ? => if not then create new one
            if( !studentMarks.ContainsKey(record.StudentId) )
                studentMarks[record.StudentId] = new Dictionary<int, Dictionary<string, decimal>>();

            //Subject exist ? => if not then create new one
            if( !studentMarks[record.StudentId].ContainsKey(record.SubjectId) )
                studentMarks[record.StudentId][record.SubjectId] = new Dictionary<string, decimal>();

            //Add field marks
            studentMarks[record.StudentId][record.SubjectId][record.FieldName] = record.Marks;
        }

        return studentMarks;
    }
    #endregion

    #region 11.11 CalculateMarksForStudents
    private void CalculateMarksForStudents(IEnumerable<dynamic> joinedData, Dictionary<int, Dictionary<int, Dictionary<string, decimal>>> studentMarks, string calculationMethod)
    {
        lblResult.Text = "";

        foreach( var studentRecord in joinedData.Select(x => new { x.StudentId, x.StudentName, x.SubjectId, x.Year, x.Semester }).Distinct() )
        {
            try
            {
                //Get subject marks for student
                var subjectMarks = studentMarks[studentRecord.StudentId][studentRecord.SubjectId];
                string expression = calculationMethod;

                //Replace field marks in expression
                foreach( var mark in subjectMarks )
                    expression = expression.Replace(mark.Key, mark.Value.ToString());

                //Calculate expression
                decimal calculatedMarks = EvaluateDynamicExpression(expression);

                //Add to result table
                Result.Rows.Add(studentRecord.StudentId, studentRecord.StudentName, studentRecord.SubjectId, calculatedMarks, studentRecord.Semester, studentRecord.Year);
            }
            catch( Exception ex )
            {
                lblResult.Text += $"Error evaluating expression for StudentId {studentRecord.StudentId}, SubjectId {studentRecord.SubjectId}: {ex.Message}<br>";
            }
        }
    }
    #endregion

    #region 11.12 Get Result Table
    public DataTable GetResultTable()
    {
        DataTable Result = new DataTable();
        Result.Columns.Add("StudentId", typeof(string));
        Result.Columns.Add("StudentName", typeof(string));
        Result.Columns.Add("SubjectId", typeof(string));
        Result.Columns.Add("CalculatedMarks", typeof(decimal));
        Result.Columns.Add("Semester", typeof(string));
        Result.Columns.Add("Year", typeof(string));


        return Result;
    }
    #endregion

}