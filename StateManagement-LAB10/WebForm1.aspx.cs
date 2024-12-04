using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StateManagement_LAB10
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void login_Click(object sender, EventArgs e)
        {
            String user = username.Text;
            String pass = password.Text;

            Session["user"] = user;
            Session["password"] = pass;

            Response.Redirect("/welcome.aspx");
        }
    }
}