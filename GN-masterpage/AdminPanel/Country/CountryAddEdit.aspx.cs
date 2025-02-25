using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GN_masterpage.AdminPanel.Country
{
    public partial class CountryAddEdit : System.Web.UI.Page
    {
        private string cs = "Data Source=DESKTOP-3EBAF6L;Initial Catalog=AddressBook;Integrated Security=True;";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void save_Click(object sender, EventArgs e)
        {
            SqlString countryName = null;
            SqlString countryCode = null;

            using(SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                using(SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType= CommandType.StoredProcedure;
                    command.CommandText = "PR_InsertCountry";

                    countryName = Cname.Text.Trim();
                    countryCode = Ccode.Text.Trim();

                    if (countryName != null)
                    {
                        txt.Text = "Enter Country Name";
                        txt.ForeColor = System.Drawing.Color.Red;
                        return;
                    }

                    if (countryCode != null)
                    {
                        txt.Text = "Enter Country Code";
                        txt.ForeColor = System.Drawing.Color.Red;
                        return;
                    }


                    if (countryCode != null && countryName != null)
                    {
                        txt.Text = "Enter Country Name and Country Code";
                        txt.ForeColor = System.Drawing.Color.Red;
                        return;
                    }


                    command.Parameters.AddWithValue("@CountryName",countryName);
                    command.Parameters.AddWithValue("@CountryCode",countryCode);

                    command.ExecuteNonQuery();

                    txt.Text = "Data Insert Succesfully";
                    txt.ForeColor = System.Drawing.Color.Green;

                    Cname.Text = "";
                    Ccode.Text = "";
                    Cname.Focus();
                    Ccode.Focus();
                }
            }
        }
    }
}