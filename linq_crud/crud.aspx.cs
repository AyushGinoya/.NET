using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class crud : System.Web.UI.Page
{
    string cs = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
        }

    }

    private void BindData()
    {
        StudentDBDataContext dataContext = new StudentDBDataContext(cs);
        GridView1.DataSource = dataContext.Students.ToList();
        GridView1.DataBind();
    }

    protected void btnRead_Click(object sender, EventArgs e)
    {
        BindData();
        CleareFields();
    }

    protected void btnCreate_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtStudentName.Text))
        {
            Label1.Text = "Name is required.";
            return;
        }

        using (StudentDBDataContext dBDataContext = new StudentDBDataContext(cs))
        {
            Student student = new Student();
            student.CPI = Convert.ToDecimal(txtStudentCPI.Text);
            student.Name = txtStudentName.Text;
            dBDataContext.Students.InsertOnSubmit(student);
            dBDataContext.SubmitChanges();
        }
        BindData();
        CleareFields();

    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {

        int id = Convert.ToInt32(txtStudentId.Text);
        using(StudentDBDataContext dBDataContext = new StudentDBDataContext(cs))
        {
            Student student = dBDataContext.Students.SingleOrDefault(st => st.StudentId == id);

            if(student != null)
            {
                student.Name = txtStudentName.Text;
                student.CPI = Convert.ToDecimal(txtStudentCPI.Text);

                dBDataContext.SubmitChanges();
                BindData();
                CleareFields();
            }
            
        }
    }

    private void CleareFields()
    {
        txtStudentCPI.Text = "";
        txtStudentId.Text = "";
        txtStudentName.Text = "";
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(txtStudentId.Text);
        using (StudentDBDataContext dBDataContext = new StudentDBDataContext(cs))
        {
            Student student = dBDataContext.Students.SingleOrDefault(st => st.StudentId == id);

            if (student != null)
            {
                dBDataContext.Students.DeleteOnSubmit(student);
                dBDataContext.SubmitChanges();
                BindData();
                CleareFields();
            }

        }

    }
}