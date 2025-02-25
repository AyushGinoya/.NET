using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PaperSolution
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Click(object sender, EventArgs e)
        {
            if(resume.HasFile)
            {
                String name = resume.FileName;
                String type = Path.GetFileName(name);

                if(type != "pdf")
                {
                    Label3.Text = "Document type must be pdf";
                    Label3.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    Label1.Text = "Name : " + name1.Text;
                    Label2.Text = "Enrollment no. : " + name1.Text;
                }
            }
            else
            {
                Label3.Text = "Please Select file";
                Label3.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}