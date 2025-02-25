using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlTypes;

namespace GN_masterpage.AdminPanel.State
{
    public partial class StateDelete : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["ab"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        private void BindGrid()
        {
            using (SqlConnection sqlConnection = new SqlConnection(cs))
            {
                sqlConnection.Open();
                using (SqlCommand cmd = new SqlCommand("PR_SelectAllState", sqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader dataReader = cmd.ExecuteReader())
                    {
                        gvCountry.DataSource = dataReader;
                        gvCountry.DataBind();
                    }
                }
            }
        }


        private void DeleteRecord(int stateId)
        {
            using (SqlConnection sqlConnection = new SqlConnection(cs))
            {
                sqlConnection.Open();
                using (SqlCommand cmd = new SqlCommand("PR_State_DeleteByPk", sqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@StateID", stateId);

                    cmd.ExecuteNonQuery(); 
                }
            }
        }


        protected void gvCountry_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteRow")
            {
                int stateId = Convert.ToInt32(e.CommandArgument);
                DeleteRecord(stateId);
                BindGrid();
                txt.Text = "State record with ID " + stateId + " has been deleted.";
            }
            else if (e.CommandName == "EditRow")
            {
                txt.Text = "Edit functionality not yet implemented for State ID: " + e.CommandArgument.ToString();
            }
        }

        
    }
}
