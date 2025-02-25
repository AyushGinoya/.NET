using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string username = txtUsername.Text.Trim();
        string password = txtPassword.Text.Trim();


        if (Page.IsValid)
        {
            if (username == "Admin" && password == "Admin")
            {
                Response.Redirect("Dashboard.aspx");
            }
            else if (username == "Demo" && password == "Demo123")
            {
                Response.Redirect("Dashboard.aspx");
            }
            else if (username == "Adm" && password == "mina@1")
            {
                Response.Redirect("Dashboard.aspx");
            }
            else
            {
                lblMessage.Text = "Invalid username or password.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
        else
        {

            lblMessage.Text = "Please fill in all required fields.";
            lblMessage.ForeColor = System.Drawing.Color.Red;
        }
    }
}