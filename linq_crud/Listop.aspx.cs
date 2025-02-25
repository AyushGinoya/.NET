using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Listop : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        List<string> name = new List<string>();
        name.Add("Ayush");
        name.Add("Deep");
        name.Add("Raj");
        name.Add("Jaydeep");
        name.Add("Kajubhai");

        var list = from name1 in name
                   from name2 in name
                   select name1 +" Vs "+name2;
        string op = string.Join("<br />", list);

        //Response.Write(op);

        var list2 = from name1 in name
                    from name2 in name
                    where name1.CompareTo(name2)<0
                    orderby name1,name2
                    select name1 + " Vs " + name2;

        string op2 = string.Join("<br />", list2);

        Response.Write(op2);
    }
}