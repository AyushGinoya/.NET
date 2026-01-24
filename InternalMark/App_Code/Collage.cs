using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class Collage
{
    #region 1.1 constructor 
    public Collage(int id, string namme, List<Subject> Subject)
    {
        CollageId = id;
        CollageName = namme;
        //  Subjects = Subject;
    }
    #endregion

    #region 1.2 Fields 
    public int CollageId { get; set; }
    public string CollageName { get; set; }
    // public List<Subject> Subjects { get; set; }
    #endregion
}
