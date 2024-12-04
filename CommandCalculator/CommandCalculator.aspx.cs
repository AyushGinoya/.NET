using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CommandCalculator
{
    public partial class CommandCalculator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Calculation(object sender, CommandEventArgs e)
        {
            string cname = e.CommandName.ToString();
            string carg = e.CommandArgument.ToString();

            if (cname == "math")
            {
                if(carg == "add")
                {
                    int a = Convert.ToInt32(num1.Text);
                    int b = Convert.ToInt32(num2.Text);

                    result.Text = Convert.ToString(a+b);
                }
                else if (carg == "sub")
                {
                    int a = Convert.ToInt32(num1.Text);
                    int b = Convert.ToInt32(num2.Text);

                    result.Text = Convert.ToString(a - b);
                }
                else if(carg == "mul")
                {
                    int a = Convert.ToInt32(num1.Text);
                    int b = Convert.ToInt32(num2.Text);

                    result.Text = Convert.ToString(a * b);
                }
                else if (carg == "div")
                {
                    int a = Convert.ToInt32(num1.Text);
                    int b = Convert.ToInt32(num2.Text);

                    result.Text = Convert.ToString(a / b);
                }
            }
            else if(cname == "clr")
            {
                num1.Text = "";
                num2.Text = "";
                result.Text = "";
            }
        }
    }
}