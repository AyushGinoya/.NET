using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace Validation_Controls
{
    public partial class Form : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if( !Page.IsPostBack )
            {

            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string email = txtEmail.Text;
            string mobileNo = txtMobileNo.Text;
            string address = txtAddress.Text;
            string password = txtPassword.Text;
            string confirmPassword = txtConfPassword.Text;
            string country = ddlCountry.SelectedItem.Text;
            string state = ddlState.SelectedItem.Text;
            string city = ddlCity.SelectedItem.Text;

            string certificates = string.Join(", ", cblCertificates.Items.Cast<ListItem>()
                                              .Where(i => i.Selected)
                                              .Select(i => i.Text));

            string gender = rblGender.SelectedItem != null ? rblGender.SelectedItem.Text : "Not Selected";

            string message = $"Name: {name}<br/>" +
                             $"Email: {email}<br/>" +
                             $"Mobile No.: {mobileNo}<br/>" +
                             $"Address: {address}<br/>" +
                             $"Country: {country}<br/>" +
                             $"State: {state}<br/>" +
                             $"City: {city}<br/>" +
                             $"Certificates: {certificates}<br/>" +
                             $"Gender: {gender}<br/>";

            Response.Write("<script>alert('Registration Successful!');</script>");
            Response.Write($"<h2>Form Data:</h2><p>{message}</p>");
        }

        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            string state = ddlState.SelectedItem.Text;

            ddlCity.Items.Clear();
            ddlCity.Items.Add(new ListItem("Select City", ""));


            if( state == "Gujarat" )
            {
                ddlCity.Items.Add("Surat");
                ddlCity.Items.Add("Ahmedabad");
                ddlCity.Items.Add("Vadodara");
            }
            else if( state == "Rajasthan" )
            {
                ddlCity.Items.Add("Jaipur");
                ddlCity.Items.Add("Udaipur");
                ddlCity.Items.Add("Ajmer");
            }
            else if( state == "Maharashtra" )
            {
                ddlCity.Items.Add("Mumbai");
                ddlCity.Items.Add("Pune");
                ddlCity.Items.Add("Lonavala");
            }
            else if( state == "California" )
            {
                ddlCity.Items.Add("Los Angeles");
                ddlCity.Items.Add("San Francisco");
                ddlCity.Items.Add("San Diego");
            }
            else if( state == "Texas" )
            {
                ddlCity.Items.Add("Houston");
                ddlCity.Items.Add("Dallas");
                ddlCity.Items.Add("Austin");
            }
            else if( state == "Georgia" )
            {
                ddlCity.Items.Add("Atlanta");
                ddlCity.Items.Add("Savannah");
                ddlCity.Items.Add("Athens");
            }
            else if( state == "Ontario" )
            {
                ddlCity.Items.Add("Toronto");
                ddlCity.Items.Add("Ottawa");
                ddlCity.Items.Add("Mississauga");
            }
            else if( state == "British Columbia" )
            {
                ddlCity.Items.Add("Vancouver");
                ddlCity.Items.Add("Victoria");
                ddlCity.Items.Add("Richmond");
            }
            else if( state == "Quebec" )
            {
                ddlCity.Items.Add("Montreal");
                ddlCity.Items.Add("Quebec City");
                ddlCity.Items.Add("Laval");
            }
            else if( state == "England" )
            {
                ddlCity.Items.Add("London");
                ddlCity.Items.Add("Manchester");
                ddlCity.Items.Add("Birmingham");
            }
            else if( state == "Scotland" )
            {
                ddlCity.Items.Add("Edinburgh");
                ddlCity.Items.Add("Glasgow");
                ddlCity.Items.Add("Aberdeen");
            }
            else if( state == "Wales" )
            {
                ddlCity.Items.Add("Cardiff");
                ddlCity.Items.Add("Swansea");
                ddlCity.Items.Add("Newport");
            }
            else if( state == "Bavaria" )
            {
                ddlCity.Items.Add("Munich");
                ddlCity.Items.Add("Nuremberg");
                ddlCity.Items.Add("Augsburg");
            }
            else if( state == "Berlin" )
            {
                ddlCity.Items.Add("Berlin");
            }
            else if( state == "Hamburg" )
            {
                ddlCity.Items.Add("Hamburg");
            }
            else if( state == "Tokyo" )
            {
                ddlCity.Items.Add("Tokyo");
            }
            else if( state == "Osaka" )
            {
                ddlCity.Items.Add("Osaka");
                ddlCity.Items.Add("Sakai");
            }
        }

        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            string country = ddlCountry.SelectedItem.Text;

            ddlState.Items.Clear();
            ddlState.Items.Add(new ListItem("Select State", ""));

            if( country == "India" )
            {
                ddlState.Items.Add("Gujarat");
                ddlState.Items.Add("Rajasthan");
                ddlState.Items.Add("Maharashtra");
            }
            else if( country == "USA" )
            {
                ddlState.Items.Add("California");
                ddlState.Items.Add("Texas");
                ddlState.Items.Add("Georgia");
            }
            else if( country == "Canada" )
            {
                ddlState.Items.Add("Ontario");
                ddlState.Items.Add("British Columbia");
                ddlState.Items.Add("Quebec");
            }
            else if( country == "England" )
            {
                ddlState.Items.Add("England");
                ddlState.Items.Add("Scotland");
                ddlState.Items.Add("Wales");
            }
            else if( country == "Germany" )
            {
                ddlState.Items.Add("Bavaria");
                ddlState.Items.Add("Berlin");
                ddlState.Items.Add("Hamburg");
            }
            else if( country == "Japan" )
            {
                ddlState.Items.Add("Tokyo");
                ddlState.Items.Add("Osaka");
            }
        }
    }
}