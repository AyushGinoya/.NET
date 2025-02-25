using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace GN_masterpage.AdminPanel.City
{
    public partial class CityAddEdit : System.Web.UI.Page
    {
        private string cs = "Data Source=DESKTOP-3EBAF6L;Initial Catalog=AddressBook;Integrated Security=True;";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                fillList();
            }
        }

        protected void save_Click(object sender, EventArgs e)
        {
            SqlInt32 StateID = SqlInt32.Null;
            SqlString CityName = SqlString.Null;
            SqlString PinCode = SqlString.Null;
            SqlString STDCode = SqlString.Null;

            string errorMsg = "";

            if (string.IsNullOrEmpty(cname.Text.Trim()))
            {
                txt.Text = "Enter City Name";
                txt.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if (string.IsNullOrEmpty(pincode.Text.Trim()))
            {
                txt.Text = "Enter Pin Code";
                txt.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if (ddlCityID.SelectedValue == "-1")
            {
                txt.Text = "Select a valid State";
                txt.ForeColor = System.Drawing.Color.Red;
                return;
            }


            StateID = Convert.ToInt32(ddlCityID.SelectedValue);
            CityName = cname.Text.Trim();
            PinCode = pincode.Text.Trim();
            STDCode = stdcode.Text.Trim();

            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                using(SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "PR_InsertCity";

                    command.Parameters.AddWithValue("@CityName", CityName);
                    command.Parameters.AddWithValue("@PinCode", PinCode);
                    command.Parameters.AddWithValue("@STDCode", STDCode);
                    command.Parameters.AddWithValue("@StateID", StateID);

                    command.ExecuteNonQuery();

                    txt.Text = "Data Insert Succesfully";
                    txt.ForeColor = System.Drawing.Color.Green;

                    cname.Text = "";
                    pincode.Text = "";
                    stdcode.Text = "";
                    cname.Focus();
                    pincode.Focus();
                    stdcode.Focus();
                }
            }
        }
        
        private void fillList()
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(cs, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "PR_State_SelectForDRopDownList";


                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            ddlCityID.DataSource = reader;
                            ddlCityID.DataValueField = "StateID";
                            ddlCityID.DataTextField = "StateName";
                            ddlCityID.DataBind();
                        }
                        ddlCityID.Items.Insert(0, new ListItem("Select State", "-1"));
                    }
                }
            }
        }
    }
}