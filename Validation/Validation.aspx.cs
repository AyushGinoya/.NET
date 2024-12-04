using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Validation
{
    public partial class Validation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sname = DropDownList1.SelectedItem.Text;

            DropDownList2.Items.Clear();
            DropDownList2.Items.Add(new ListItem("Select State", ""));

            if (sname == "India")
            {
                DropDownList2.Items.Add("Gujarat");
                DropDownList2.Items.Add("Rajasthan");
                DropDownList2.Items.Add("Maharashtra");
                DropDownList2.Items.Add("Karnataka");
                DropDownList2.Items.Add("Punjab");
            }
            else if (sname == "USA")
            {
                DropDownList2.Items.Add("California");
                DropDownList2.Items.Add("Texas");
                DropDownList2.Items.Add("Georgia");
                DropDownList2.Items.Add("New York");
                DropDownList2.Items.Add("Florida");
            }
            else if (sname == "Canada")
            {
                DropDownList2.Items.Add("Ontario");
                DropDownList2.Items.Add("British Columbia");
                DropDownList2.Items.Add("Quebec");
                DropDownList2.Items.Add("Alberta");
                DropDownList2.Items.Add("Manitoba");
            }
            else if (sname == "United Kingdom")
            {
                DropDownList2.Items.Add("England");
                DropDownList2.Items.Add("Scotland");
                DropDownList2.Items.Add("Wales");
                DropDownList2.Items.Add("Northern Ireland");
            }
            else if (sname == "Germany")
            {
                DropDownList2.Items.Add("Bavaria");
                DropDownList2.Items.Add("Berlin");
                DropDownList2.Items.Add("Hamburg");
                DropDownList2.Items.Add("Saxony");
                DropDownList2.Items.Add("Hesse");
            }
            else if (sname == "Japan")
            {
                DropDownList2.Items.Add("Tokyo");
                DropDownList2.Items.Add("Osaka");
                DropDownList2.Items.Add("Kyoto");
                DropDownList2.Items.Add("Hokkaido");
                DropDownList2.Items.Add("Fukuoka");
            }
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string state = DropDownList2.SelectedItem.Text;

            DropDownList3.Items.Clear();
            DropDownList3.Items.Add(new ListItem("Select City", ""));

            if (state == "Gujarat")
            {
                DropDownList3.Items.Add("Surat");
                DropDownList3.Items.Add("Ahmedabad");
                DropDownList3.Items.Add("Vadodara");
            }
            else if (state == "Rajasthan")
            {
                DropDownList3.Items.Add("Jaipur");
                DropDownList3.Items.Add("Udaipur");
                DropDownList3.Items.Add("Ajmer");
            }
            else if (state == "Maharashtra")
            {
                DropDownList3.Items.Add("Mumbai");
                DropDownList3.Items.Add("Pune");
                DropDownList3.Items.Add("Lonavala");
            }
            else if (state == "California")
            {
                DropDownList3.Items.Add("Los Angeles");
                DropDownList3.Items.Add("San Francisco");
                DropDownList3.Items.Add("San Diego");
            }
            else if (state == "Texas")
            {
                DropDownList3.Items.Add("Houston");
                DropDownList3.Items.Add("Dallas");
                DropDownList3.Items.Add("Austin");
            }
            else if (state == "Georgia")
            {
                DropDownList3.Items.Add("Atlanta");
                DropDownList3.Items.Add("Savannah");
                DropDownList3.Items.Add("Athens");
            }
            else if (state == "Ontario")
            {
                DropDownList3.Items.Add("Toronto");
                DropDownList3.Items.Add("Ottawa");
                DropDownList3.Items.Add("Mississauga");
            }
            else if (state == "British Columbia")
            {
                DropDownList3.Items.Add("Vancouver");
                DropDownList3.Items.Add("Victoria");
                DropDownList3.Items.Add("Richmond");
            }
            else if (state == "Quebec")
            {
                DropDownList3.Items.Add("Montreal");
                DropDownList3.Items.Add("Quebec City");
                DropDownList3.Items.Add("Laval");
            }
            else if (state == "England")
            {
                DropDownList3.Items.Add("London");
                DropDownList3.Items.Add("Manchester");
                DropDownList3.Items.Add("Birmingham");
            }
            else if (state == "Scotland")
            {
                DropDownList3.Items.Add("Edinburgh");
                DropDownList3.Items.Add("Glasgow");
                DropDownList3.Items.Add("Aberdeen");
            }
            else if (state == "Wales")
            {
                DropDownList3.Items.Add("Cardiff");
                DropDownList3.Items.Add("Swansea");
                DropDownList3.Items.Add("Newport");
            }
            else if (state == "Bavaria")
            {
                DropDownList3.Items.Add("Munich");
                DropDownList3.Items.Add("Nuremberg");
                DropDownList3.Items.Add("Augsburg");
            }
            else if (state == "Berlin")
            {
                DropDownList3.Items.Add("Berlin");
            }
            else if (state == "Hamburg")
            {
                DropDownList3.Items.Add("Hamburg");
            }
            else if (state == "Tokyo")
            {
                DropDownList3.Items.Add("Tokyo");
            }
            else if (state == "Osaka")
            {
                DropDownList3.Items.Add("Osaka");
                DropDownList3.Items.Add("Sakai");
            }
        }

        protected void CheckBoxList1_Validate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = CheckBoxList1.Items.Cast<ListItem>().Any(item => item.Selected);
        }

        protected void Password_CustomValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string password = args.Value;
            if (password.Length < 8 ||
                !Regex.IsMatch(password, "[A-Z]") ||
                !Regex.IsMatch(password, "[0-9]"))
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // Validating and processing form data
            if (Page.IsValid)
            {
                string name = TextBox1.Text;
                string email = TextBox3.Text;
                string mobile = TextBox2.Text;
                string country = DropDownList1.SelectedItem.Text;
                string state = DropDownList2.SelectedItem.Text;
                string city = DropDownList3.SelectedItem.Text;
                string address = TextBox4.Text;
                string gender = RadioButtonList1.SelectedItem.Text;

                List<string> certificates = new List<string>();
                foreach (ListItem item in CheckBoxList1.Items)
                {
                    if (item.Selected)
                    {
                        certificates.Add(item.Text);
                    }
                }

                string certificatesSelected = string.Join(", ", certificates);
                string password = TextBox5.Text;

                // Displaying user data (could be saved in database)
                Label2.Text = $"Name: {name}<br>Email: {email}<br>Mobile: {mobile}<br>Country: {country}<br>State: {state}<br>City: {city}<br>Address: {address}<br>Gender: {gender}<br>Certificates: {certificatesSelected}<br>Password: {password}";
            }
        }
    }
}