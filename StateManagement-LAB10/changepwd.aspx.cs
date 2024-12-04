using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StateManagement_LAB10
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void save_Click(object sender, EventArgs e)
        {
            string oldPwdSs = "";
            string newPwd = "";
            if (Session["user"] != null)
            {
                oldPwdSs = Session["password"].ToString();

                if (oldPwdSs.Equals(oldpwd.Text))
                {
                    newPwd = newpwd.Text;
                    Session["password"] = newPwd;
                    Response.Write("Pwd Updated");
                   // Response.Redirect("/welcome.aspx");
                }
                else
                {
                    Response.Write("Entered Old Pwd is wrong");
                }
            }
        }

        protected void back_Click(object sender, EventArgs e)
        {
            Response.Redirect("/welcome.aspx");
        }
    }
}