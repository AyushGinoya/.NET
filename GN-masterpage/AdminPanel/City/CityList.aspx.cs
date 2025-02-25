using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GN_masterpage.AdminPanel.City
{
    public partial class CityList : System.Web.UI.Page
    {
        private string cs = "Data Source=DESKTOP-3EBAF6L;Initial Catalog=AddressBook;Integrated Security=True;";
        protected void Page_Load(object sender, EventArgs e)
        {
            using (SqlConnection sqlConnection = new SqlConnection())
            {
                sqlConnection.ConnectionString = cs;
                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.CommandText = "PR_SelectAllCity";

                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        gvCountry.DataSource = dataReader;
                        gvCountry.DataBind();
                    }
                }
            }

        }
    }
}