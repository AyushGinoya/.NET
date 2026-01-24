using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;


public class Student
{
    #region 2.1 constructor 
    public Student(int StudentId, string StudentName, int CollageId, int branchID)
    {
        this.StudentId = StudentId;
        this.StudentName = StudentName;
        this.CollageId = CollageId;
        this.BranchID = branchID;
    }

    #endregion

    #region 2.2 Fields 
    public int StudentId { get; set; }
    public string StudentName { get; set; }
    public int CollageId { get; set; }
    public int BranchID { get; set; }
    #endregion
}