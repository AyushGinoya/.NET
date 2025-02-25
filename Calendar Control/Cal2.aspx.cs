using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Calendar_Control
{
    public partial class Cal2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            DateTime startdt = DateTime.Now;
            DateTime enddt = startdt.AddDays(3);

            // Check if the current cell's date falls within the specified range
            if (e.Day.Date >= startdt && e.Day.Date <= enddt)
            {
                e.Cell.BackColor = Color.Red;
                e.Cell.ToolTip = "Sessional Exam";
                e.Day.IsSelectable = false;
            }
        }

        protected void Calendar2_DayRender(object sender, DayRenderEventArgs e)
        {
            DateTime[] holidays =
            {
        new DateTime(DateTime.Now.Year, 1, 1),   
        new DateTime(DateTime.Now.Year, 8, 15),  
        new DateTime(DateTime.Now.Year, 10, 2),  
        new DateTime(DateTime.Now.Year, 12, 25), 
        new DateTime(DateTime.Now.Year, 7, 17),  
        new DateTime(DateTime.Now.Year, 8, 19),  
        new DateTime(DateTime.Now.Year, 10, 31)  
    };

            DateTime birthday = new DateTime(DateTime.Now.Year, 11, 9);

            DateTime ses1start = new DateTime(DateTime.Now.Year, 7, 29);
            DateTime ses1end = ses1start.AddDays(2);

            DateTime ses2start = new DateTime(DateTime.Now.Year, 9, 2);
            DateTime ses2end = ses2start.AddDays(2);

            DateTime ses3start = new DateTime(DateTime.Now.Year, 10, 8);
            DateTime ses3end = ses3start.AddDays(2);

            DateTime extstart = new DateTime(DateTime.Now.Year, 11, 19);
            DateTime extend = extstart.AddDays(3);

            // Highlight holidays in green
            foreach (DateTime holiday in holidays)
            {
                if (e.Day.Date == holiday)
                {
                    e.Cell.BackColor = System.Drawing.Color.Green;
                    e.Cell.ToolTip = "Holiday";
                }
            }

            // Highlight birthday in yellow
            if (e.Day.Date == birthday)
            {
                e.Cell.BackColor = System.Drawing.Color.Yellow;
                e.Cell.ToolTip = "Birthday";
            }

            // Sessional Exam 1 in red
            if (e.Day.Date >= ses1start && e.Day.Date <= ses1end)
            {
                e.Cell.BackColor = System.Drawing.Color.Red;
                e.Cell.ToolTip = "Sessional 1";
                e.Day.IsSelectable = false;
            }

            // Sessional Exam 2 in red
            if (e.Day.Date >= ses2start && e.Day.Date <= ses2end)
            {
                e.Cell.BackColor = System.Drawing.Color.Red;
                e.Cell.ToolTip = "Sessional 2";
                e.Day.IsSelectable = false;
            }

            // Sessional Exam 3 in red
            if (e.Day.Date >= ses3start && e.Day.Date <= ses3end)
            {
                e.Cell.BackColor = System.Drawing.Color.Red;
                e.Cell.ToolTip = "Sessional 3";
                e.Day.IsSelectable = false;
            }

            // External Exam dates in red
            if (e.Day.Date >= extstart && e.Day.Date <= extend)
            {
                e.Cell.BackColor = System.Drawing.Color.Red;
                e.Cell.ToolTip = "External";
                e.Day.IsSelectable = false;
            }

            // Weekends in red
            if (e.Day.IsWeekend)
            {
                e.Cell.BackColor = System.Drawing.Color.Red;
                e.Cell.ToolTip = "Weekend";
            }

            // Dates in other months in blue
            if (e.Day.IsOtherMonth)
            {
                e.Cell.BackColor = System.Drawing.Color.DeepSkyBlue;
                e.Cell.ToolTip = "Other Month";
            }
        }

    }
}