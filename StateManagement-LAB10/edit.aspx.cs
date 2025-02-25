using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StateManagement_LAB10
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void save_Click(object sender, EventArgs e)
        {
            string olduserSs = "";
            string newUser = "";
            if (Session["user"] != null)
            {
                olduserSs = Session["user"].ToString();

                if (olduserSs.Equals(olduser.Text))
                {
                    newUser = newuser.Text;
                    Session["user"] = newUser;
                    Response.Write("Name Updated");
                    // Response.Redirect("/welcome.aspx");
                }
                else
                {
                    Response.Write("Entered Old Name is wrong");
                }
            }
        }

        protected void back_Click(object sender, EventArgs e)
        {
            Response.Redirect("/welcome.aspx");
        }
    }
}