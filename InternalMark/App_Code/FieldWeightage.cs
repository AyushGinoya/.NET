using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class FieldWeightage
{
    #region 3.1 constructor 
    public FieldWeightage(int StudentId, int id, int Year, int Semester, string fieldName, decimal weightage, int SubjectId)
    {
        this.StudentId = StudentId;
        CollageId = id;
        this.Year = Year;
        this.Semester = Semester;
        FieldName = fieldName;
        Marks = weightage;
        this.SubjectId = SubjectId;
    }
    #endregion

    #region 3.2 Fields 
    public int StudentId { get; set; }
    public int CollageId { get; set; }
    public int Semester { get; set; }
    public int Year { get; set; }
    public string FieldName { get; set; }
    public int SubjectId { get; set; }
    public decimal Marks { get; set; }
    #endregion

}