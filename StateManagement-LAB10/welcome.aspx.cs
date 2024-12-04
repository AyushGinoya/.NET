using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StateManagement_LAB10
{
    public partial class welcome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                user1.Text = Session["user"].ToString();
                pwd.Text = Session["password"].ToString();
            }
            else
            {
                Response.Redirect("/WebForm1.aspx");
            }
        }

        protected void cpwd_Click(object sender, EventArgs e)
        {
            Response.Redirect("/changepwd.aspx");
        }

        protected void logout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("/WebForm1.aspx");
        }

        protected void edit_Click(object sender, EventArgs e)
        {
            Response.Redirect("/edit.aspx");
        }
    }
}