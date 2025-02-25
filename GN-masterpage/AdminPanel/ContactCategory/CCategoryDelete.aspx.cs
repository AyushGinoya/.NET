using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

namespace GN_masterpage.AdminPanel.ContactCategory
{
    public partial class CCategoryDelete : System.Web.UI.Page
    {

        string cs = ConfigurationManager.ConnectionStrings["ab"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DataBind();
            }
        }

        private void DataBind()
        {
            try
            {
                using(SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("PR_SelectAllContactCategory",conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        using(SqlDataReader reader = cmd.ExecuteReader())
                        {
                            gvCC.DataSource = reader;
                            gvCC.DataBind();
                        }
                    }
                }   
            }catch(Exception ex){ 
                Response.Write(ex.Message);
            }
        }

        private void DeleteRecord(int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("PR_DeleteContactCategoryByPk", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ContactCategoryID", id);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
        protected void gvCC_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "DeleteRow")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                DeleteRecord(id);
                DataBind();
                txt.Text = "ContactCategory record with ID " + id + " has been deleted.";
            }
        }
    }
}