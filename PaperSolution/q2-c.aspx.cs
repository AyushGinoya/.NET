using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PaperSolution
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Click(object sender, EventArgs e)
        {
            int row = Convert.ToInt32(Rows.SelectedItem.Text);
            int col = Convert.ToInt32(Columns.SelectedItem.Text);

            Table t = new Table();

            for(int i = 0; i < row; i++)
            {
                TableRow r = new TableRow();
                for(int j = 0; j < col; j++)
                {
                    TableCell c = new TableCell();
                    if(Type.SelectedItem.Text == "TextBox")
                    {
                       // c.Text = Type.SelectedItem.ToString();
                       TextBox tx = new TextBox();

                        c.Controls.Add(tx);
                    }else if(Type.SelectedItem.Text == "HyperLink")
                    {
                        //c.Text = Type.SelectedItem.ToString();
                        HyperLink h = new HyperLink();
                        h.Text = Type.SelectedItem.Text;
                        c.Controls.Add(h);
                    }
                    else if (Type.SelectedItem.Text == "LinkButton")
                    {
                       // c.Text = Type.SelectedItem.ToString();
                       LinkButton linkButton = new LinkButton();
                        linkButton.Text = Type.SelectedItem.Text;
                        c.Controls.Add(linkButton);
                    }
                    r.Cells.Add(c);
                }
                t.Rows.Add(r);
            }
            table.Controls.Add(t);
        }
    }
}