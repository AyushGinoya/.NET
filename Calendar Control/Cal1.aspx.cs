using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Calendar_Control
{
    public partial class Cal1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label2.Text = "Selected date: " + Calendar1.SelectedDate.ToShortDateString();
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            Label3.Text = "Current Date : " + Calendar1.TodaysDate.ToShortDateString();
            Label4.Text = "Current Date : " + Calendar1.TodaysDate.ToString("d");
            Label5.Text = "Current Date : " + Calendar1.TodaysDate.ToString("D");
        }

        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            //2nd Saturday
            if (e.Day.Date.Day>=8 && e.Day.Date.Day <= 14)
            {
                if(e.Day.Date.DayOfWeek== DayOfWeek.Saturday)
                {
                    e.Cell.BackColor = Color.Red;
                    e.Day.IsSelectable=false;
                    e.Cell.ToolTip = "2nd Saturday";
                }
            }
        }

        protected void Calendar2_DayRender(object sender, DayRenderEventArgs e)
        {
            //Check for sunday
            if (e.Day.Date.DayOfWeek == DayOfWeek.Sunday)
            {
                e.Cell.BackColor = Color.Orange;
                e.Day.IsSelectable=false;
                e.Cell.ToolTip = "Sunday";
            }

            //for current year
            if(e.Day.Date.Year != DateTime.Now.Year)
            {
                e.Cell.BackColor = Color.Maroon;
                e.Day.IsSelectable = false;
                e.Cell.ToolTip = "Out of range";
            }
        }

        protected void Calendar3_DayRender(object sender, DayRenderEventArgs e)
        {

        }

        // check only on current year and mounth>=current.Month
        protected void Calendar3_VisibleMonthChanged(object sender, MonthChangedEventArgs e)
        {
            if(e.NewDate.Month == DateTime.Now.Month)
            {
                Calendar3.PrevMonthText = "";
            }
            else
            {
                Calendar3.PrevMonthText = "&lt";
            }

            if (e.NewDate.Month == 12)
            {
                Calendar3.NextMonthText = "";
            }
            else
            {
                Calendar3.NextMonthText = "&lt";
            }
        }
    }
}