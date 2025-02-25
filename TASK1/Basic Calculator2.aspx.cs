using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Basic_Calculator2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnCalculate_Click(object sender, EventArgs e)
    {
        double num1=Convert.ToDouble(txtNumber1.Text), num2=Convert.ToDouble(txtNumber2.Text), result = 0;

            string operation = ddlOperations.SelectedValue;

            switch (operation)
            {
                case "add":
                    result = num1 + num2;
                    break;
                case "subtract":
                    result = num1 - num2;
                    break;
                case "multiply":
                    result = num1 * num2;
                    break;
                case "divide":
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                    }
                    else
                    {
                        lblResult.Text = "Result: Cannot divide by zero!";
                        return;
                    }
                    break;
                case "modulo":
                    if (num2 != 0)
                    {
                        result = num1 % num2;
                    }
                    else
                    {
                        lblResult.Text = "Result: Cannot modulo by zero!";
                        return;
                    }
                    break;
                default:
                    lblResult.Text = "Result: Please select an operation!";
                    return;
            }
        lblResult.Text = "Result: " + result.ToString();
    }
}