using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Contact_Form : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            string name = txtName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string message = txtMessage.Text.Trim();

            lblThankYou.Text = $"Thank you, {name}! Your message has been sent.";
            lblThankYou.ForeColor = System.Drawing.Color.Green;

            txtName.Text = "";
            txtEmail.Text = "";
            txtMessage.Text = "";
        }
    }
}