using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace abc
{
    public partial class my : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        string cs = "Data Source=DESKTOP-3EBAF6L ;Initial catalog =WT-Collage ;Integrated Security=True";

        protected void Button1_Click(object sender, EventArgs e)
        {
            display();
        }
        protected void display()
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {

                SqlCommand sqlCommand = conn.CreateCommand();
                sqlCommand.Connection = conn;
                sqlCommand.CommandText = "Select * from Student";

                SqlDataReader reader;
                conn.Open();
                reader = sqlCommand.ExecuteReader();
                GridView1.DataSource = reader;
                GridView1.DataBind();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                string query = "INSERT INTO Student  VALUES (" + TextBox1.Text + ", '" + TextBox2.Text + "', '" +
                    TextBox3.Text + "', '" + TextBox4.Text + "', '" + TextBox5.Text + "')";
                SqlCommand sqlCommand = new SqlCommand(query, conn);
                conn.Open();
                int n = sqlCommand.ExecuteNonQuery();
                if (n == 0)
                {
                    Response.Write("Insert error");
                }
                else
                {
                    display();
                }
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                string query = "UPDATE Student SET Name = '" +
    TextBox2.Text + "', Semester = '" +
    TextBox3.Text + "', Dept = '" +
    TextBox4.Text + "', CPI = '" +
    TextBox5.Text + "' WHERE ID = " + TextBox1.Text;
                SqlCommand sqlCommand = new SqlCommand(query, conn);
                conn.Open();
                int n = sqlCommand.ExecuteNonQuery();
                if (n == 0)
                {
                    Response.Write("Update error");
                }
                else
                {
                    display();
                }
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                string query = "DELETE FROM Student WHERE ID = " + TextBox1.Text;

                SqlCommand sqlCommand = new SqlCommand(query, conn);
                conn.Open();
                int n = sqlCommand.ExecuteNonQuery();
                if (n == 0)
                {
                    Response.Write("Delete error");
                }
                else
                {
                    display();
                }
            }
        }
    }
}