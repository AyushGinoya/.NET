using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Basic_Calculator_ : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void btnAdd_Click(object sender, EventArgs e)
    {
        PerformOp("add");
    }

    private void PerformOp(string operation)
    {
        double num1, num2, result = 0;

        if (double.TryParse(txtNumber1.Text, out num1) && double.TryParse(txtNumber2.Text, out num2))
        {
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
            }

            lblResult.Text = "Result: " + result.ToString();
        }
        else
        {
            lblResult.Text = "Result: Please enter valid numbers!";
        }
    }

    protected void btnSubtract_Click(object sender, EventArgs e)
    {
        PerformOp("subtract");
    }

    protected void btnMultiply_Click(object sender, EventArgs e)
    {
        PerformOp("multiply");
    }

    protected void btnModulo_Click(object sender, EventArgs e)
    {
        PerformOp("modulo");
    }

    protected void btnDivide_Click(object sender, EventArgs e)
    {
        PerformOp("divide");
    }
}