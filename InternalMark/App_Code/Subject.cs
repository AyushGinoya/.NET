using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Subject
{
    public Subject(int subjectId, string subjectName)
    {
        this.SubjectId = subjectId;
        this.SubjectName = subjectName;
    }

    public string SubjectName { get; set; }
    public int SubjectId { get; set; }
}