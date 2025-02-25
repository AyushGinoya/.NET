using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace GN_masterpage.AdminPanel.ContactCategory
{
    public partial class ContactCategoryAddEdit : System.Web.UI.Page
    {
        private string cs = "Data Source=DESKTOP-3EBAF6L;Initial Catalog=AddressBook;Integrated Security=True;";
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void save_Click(object sender, EventArgs e)
        {
            SqlString cName = null;
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "PR_InsertContactCategory";

                    if (CCname.Text.Trim().Length > 0)
                    {
                        cName = CCname.Text.Trim();

                        command.Parameters.AddWithValue("@ContactCategoryName", cName);

                        command.ExecuteNonQuery();


                        txt.Text = "Data Insert Succesfully";
                        txt.ForeColor = System.Drawing.Color.Green;

                        CCname.Text = "";
                        CCname.Focus();
                    }
                }
            }
        }
    }
}