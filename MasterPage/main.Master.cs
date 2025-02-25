using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MasterPage
{
    public partial class main : System.Web.UI.MasterPage
    {
        [TemplateContainer(typeof(main))]
        [TemplateInstance(TemplateInstance.Single)]
        public virtual ITemplate Template_head { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SubjectRadioButtons_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedSubject = SubjectRadioButtons.SelectedValue;

            if (selectedSubject == "IT")
            {
                Response.Redirect("IT.aspx");
            }
            else if (selectedSubject == "CR")
            {
                Response.Redirect("CR.aspx");
            }
            else if (selectedSubject == "EC")
            {
                Response.Redirect("EC.aspx");
            }
            else
            {
                Response.Redirect("Home.aspx");
            }
        }
    }
}