using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TableRuntime
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Table table = new Table();

            int row = Convert.ToInt32(ddlrow.SelectedItem.Text);
            int col = Convert.ToInt32(ddlcol.SelectedItem.Text);

            for(int i = 1; i <= row; i++)
            {
                TableRow tableRow = new TableRow();
                tableRow.BorderStyle = BorderStyle.Double;
                tableRow.BorderColor = System.Drawing.Color.Blue;

                for (int j = 1; j <= col; j++)
                {
                    TableCell cell = new TableCell();
                    cell.BorderStyle = BorderStyle.Double;
                    cell.BorderColor = System.Drawing.Color.Red;
                    HyperLink link = new HyperLink();
                    link.Text = Convert.ToString(i*j);

                    cell.Controls.Add(link);
                    tableRow.Cells.Add(cell);
                }

                table.Rows.Add(tableRow);
                table.BorderStyle = BorderStyle.Double;
                table.BorderColor = System.Drawing.Color.Green;
                PlaceHolder1.Controls.Add(table);
            }
        }
    }
}