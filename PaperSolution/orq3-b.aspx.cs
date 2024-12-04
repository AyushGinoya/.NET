using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PaperSolution
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Purchese_Click(object sender, EventArgs e)
        {
            int cost = 0;

            foreach (ListItem item in List.Items)
            {
                if (item.Selected)
                {
                    cost += Convert.ToInt32(item.Value);
                    Display.Text += item.Text + "  ";
                }
            }

            Total.Text = cost.ToString();
            Total.Enabled = false;
            Display.Visible = true;
        }
    }
}