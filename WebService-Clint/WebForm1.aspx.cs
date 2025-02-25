using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebService_Clint.localhost;

namespace WebService_Clint
{ 
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGetDetails_Click(object sender, EventArgs e)
        {
            GetStudentDetails studentDetails = new GetStudentDetails();
            gvEmployeeDetails.DataSource = studentDetails.getEmployeetDetaills(txtEmployeeID.Text);
            gvEmployeeDetails.DataBind();
        }
    }
}