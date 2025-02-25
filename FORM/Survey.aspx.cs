using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Survey : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string surveyResults = "Survey Results:<br />";

        if (rblLanguages.SelectedIndex != -1)
        {
            surveyResults += "Favorite programming language: " + rblLanguages.SelectedItem.Text + "<br />";
        }
        else
        {
            surveyResults += "Favorite programming language: Not selected<br />";
        }

        string selectedTechnologies = "";
        foreach (ListItem item in cblTechnologies.Items)
        {
            if (item.Selected)
            {
                selectedTechnologies += item.Text + ", ";
            }
        }

        if (!string.IsNullOrEmpty(selectedTechnologies))
        {
            surveyResults += "Technologies worked with: " + selectedTechnologies.TrimEnd(',', ' ') + "<br />";
        }
        else
        {
            surveyResults += "Technologies worked with: Not selected<br />";
        }

        lblThankYou.Text = "Thank you for participating in the survey!";
        lblSurveyResults.Text = surveyResults;
    }
}