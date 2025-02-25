using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRUD
{
    public partial class Student : System.Web.UI.Page
    {
        //String cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
       String cs = "Data Source=DESKTOP-3EBAF6L;Initial Catalog=Collage;Integrated Security=True;TrustServerCertificate=True";
        // String cs = "Data Source=(LocalDB)\\MSSQLLocalDB initial catalog = WT Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();
                    SqlCommand sqlCommand = conn.CreateCommand();
                    sqlCommand.Connection = conn;
                    sqlCommand.CommandText = "SELECT * FROM Student";

                    
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    GridView1.DataSource = reader;
                    GridView1.DataBind();
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }

        
        protected void Button3_Click(object sender, EventArgs e)
        {

        }

        protected void Button4_Click(object sender, EventArgs e)
        {

        }
    }
}