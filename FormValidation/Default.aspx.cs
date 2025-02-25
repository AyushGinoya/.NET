using System;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    string connectionString = "Data Source=GNWEBSOFT;Initial Catalog=Test;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;";
    private bool isTransfer = false;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!isTransfer)
        {
            isTransfer = false;
        }
        else
        {
            
        }
        if (!IsPostBack)
        {
            LoadCountry();
        }
    }

    #region LoadCountry
    private void LoadCountry()
    {
        string query = "SELECT CountryID, CountryName FROM Countries";
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            ddlcountry.Items.Clear();
            ddlcountry.Items.Add(new ListItem("Select Country", "-1"));

            while (reader.Read())
            {
                ddlcountry.Items.Add(new ListItem(reader["CountryName"].ToString(), reader["CountryID"].ToString()));
            }
        }
    }
    #endregion

    #region LoadStates
    private void LoadStates(int countryID)
    {
        string query = "SELECT StateId, StateName FROM States WHERE CountryId = @CountryID";
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@CountryID", countryID);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            Dropstate.Items.Clear();
            Dropstate.Items.Add(new ListItem("Select State", "-1"));

            while (reader.Read())
            {
                Dropstate.Items.Add(new ListItem(reader["StateName"].ToString(), reader["StateId"].ToString()));
            }
        }
    }
    #endregion

    #region LoadCities
    private void LoadCities(int stateID)
    {
        string query = "SELECT CityId, CityName FROM Cities WHERE StateId = @StateID";
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@StateId", stateID);

            conn.Open();    

            Dropcity.Items.Clear();
            ddlcountry.Items.Add(new ListItem("Select city", "-1"));

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Dropcity.Items.Add(new ListItem(reader["CityName"].ToString(), reader["CityId"].ToString()));
            }
            
        }
    }
    #endregion

    #region Submit clicked
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string nameValue = name.Text;
        string enrollmentValue = enrollment.Text;
        string emailValue = email.Text;
        string mobileValue = mobile.Text;
        string addressValue = address.Text;
        string pincodeValue = pincode.Text;
        string countryValue = ddlcountry.SelectedItem.Text;
        string stateValue = Dropstate.SelectedItem.Text;
        string cityValue = Dropcity.SelectedItem.Text;

        string hobbies = "";
        foreach (ListItem item in hobby.Items)
        {
            if (item.Selected)
            {
                hobbies += item.Text + ", ";
            }
        }

        if (hobbies.Length > 0)
        {
            hobbies = hobbies.Substring(0, hobbies.Length - 2);
        }

        lblResult.Text = $"Name: {nameValue}<br/>" +
                         $"Enrollment No.: {enrollmentValue}<br/>" +
                         $"Email: {emailValue}<br/>" +
                         $"Mobile No.: {mobileValue}<br/>" +
                         $"Address: {addressValue}<br/>" +
                         $"Pincode: {pincodeValue}<br/>" +
                         $"Country: {countryValue}<br/>" +
                         $"State: {stateValue}<br/>" +
                         $"City: {cityValue}<br/>" +
                         $"Hobbies: {hobbies}";
    }

    #endregion

    #region ddlcountry_SelectedIndexChanged
    protected void ddlcountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        int countryID = Convert.ToInt32(ddlcountry.SelectedValue);
        if (countryID != -1)
        {
            LoadStates(countryID);
        }
        else
        {
            Dropstate.Items.Clear();
            Dropstate.Items.Add(new ListItem("Select State", "-1"));
        }
    }
    #endregion

    #region Dropstate_SelectedIndexChanged
    protected void Dropstate_SelectedIndexChanged(object sender, EventArgs e)
    {
        int stateID = Convert.ToInt32(Dropstate.SelectedValue);
        if (stateID != -1)
        {
            LoadCities(stateID);
        }
        else
        {
            Dropcity.Items.Clear();
            Dropcity.Items.Add(new ListItem("Select City", "-1"));
        }
    }
    #endregion

    protected void Dropcity_SelectedIndexChanged(object sender, EventArgs e)
    {
     
    }

    protected void addcountry_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddCountry.aspx");
    }

    #region Country refresh
    protected void refresh_Click(object sender, ImageClickEventArgs e)
    {
        LoadCountry();
    }
    #endregion
}
