using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Web.UI.WebControls;

namespace GN_masterpage.AdminPanel.State
{
    public partial class StateAddEdit : System.Web.UI.Page
    {
        private string cs = "Data Source=DESKTOP-3EBAF6L;Initial Catalog=AddressBook;Integrated Security=True;";
        #region Page Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                fillDDList();

                if (Request.QueryString["StateID"] != null)
                {
                    fillControlls(Convert.ToInt32(Request.QueryString["StateID"]));
                }
            }
        }

        #endregion Page Load

        #region Button : Save
        protected void save_Click(object sender, EventArgs e)
        {
            SqlInt32 countryID = SqlInt32.Null;
            SqlString stateName = SqlString.Null;
            SqlString stateCode = SqlString.Null;

            // Input validation
            if (string.IsNullOrWhiteSpace(Sname.Text.Trim()))
            {
                txt.Text = "Enter State Name";
                txt.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if (string.IsNullOrWhiteSpace(Scode.Text.Trim()))
            {
                txt.Text = "Enter State Code";
                txt.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if (ddlCountryID.SelectedIndex == 0)
            {
                txt.Text = "Select Country";
                txt.ForeColor = System.Drawing.Color.Red;
                return;
            }

            // Assign values after validation
            stateName = Sname.Text.Trim();
            stateCode = Scode.Text.Trim();
            countryID = Convert.ToInt32(ddlCountryID.SelectedValue);

            try
            {
                using (SqlConnection connection = new SqlConnection(cs))
                {
                    connection.Open();
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        if (Request.QueryString["StateID"] != null)
                        {
                            // Edit mode
                            command.CommandText = "PR_State_UpdateByPk";
                            command.Parameters.AddWithValue("@StateID", Convert.ToInt32(Request.QueryString["StateID"]));
                        }
                        else
                        {
                            // Add mode
                            command.CommandText = "PR_InsertState";
                        }

                        command.Parameters.AddWithValue("@StateName", stateName);
                        command.Parameters.AddWithValue("@StateCode", stateCode);
                        command.Parameters.AddWithValue("@CountryID", countryID);

                        command.ExecuteNonQuery();

                        if (Request.QueryString["StateID"] != null)
                        {
                            Response.Redirect("~/AdminPanel/State/StateList.aspx");
                        }
                        else
                        {
                            txt.Text = "Data Inserted Successfully";
                            txt.ForeColor = System.Drawing.Color.Green;

                            Sname.Text = "";
                            Scode.Text = "";
                            ddlCountryID.SelectedIndex = 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                txt.Text = "Error: " + ex.Message;
                txt.ForeColor = System.Drawing.Color.Red;
            }
        }
        #endregion Button : Save

        #region fillDDList
        private void fillDDList()
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("Country_SelectForDropDownList", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            ddlCountryID.DataSource = reader;
                            ddlCountryID.DataValueField = "CountryID";
                            ddlCountryID.DataTextField = "CountryName";
                            ddlCountryID.DataBind();
                        }
                        ddlCountryID.Items.Insert(0, new ListItem("Select Country", "-1"));
                    }
                }
            }
        }
        #endregion fillDDList
        private void fillControlls(SqlInt32 stateID)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(cs))
                {
                    sqlConnection.Open();
                    using (SqlCommand cmd = sqlConnection.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "PR_State_SelectByPk";
                        cmd.Parameters.AddWithValue("@StateID", stateID);

                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            if (!reader["StateName"].Equals(DBNull.Value))
                            {
                                Sname.Text = reader["StateName"].ToString().Trim();
                            }

                            if (!reader["CountryID"].Equals(DBNull.Value))
                            {
                                ddlCountryID.SelectedValue = reader["CountryID"].ToString().Trim(); // Properly select dropdown value
                            }

                            if (!reader["StateCode"].Equals(DBNull.Value))
                            {
                                Scode.Text = reader["StateCode"].ToString().Trim();
                            }
                        }
                        else
                        {
                            txt.Text = "No state found with id = " + stateID;
                            txt.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                txt.Text = "Error: " + ex.Message;
                txt.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminPanel/State/StateList.aspx",true);
        }
    }
}
