<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Survey.aspx.cs" Inherits="Survey" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h3>1. What is your favorite programming language?</h3>
            <asp:RadioButtonList ID="rblLanguages" runat="server">
                <asp:ListItem Text="C#" Value="C#" />
                <asp:ListItem Text="Java" Value="Java" />
                <asp:ListItem Text="Python" Value="Python" />
                <asp:ListItem Text="JavaScript" Value="JavaScript" />
            </asp:RadioButtonList>
            <br />

            <h3>2. Which of the following technologies have you worked with?</h3>
            <asp:CheckBoxList ID="cblTechnologies" runat="server">
                <asp:ListItem Text="ASP.NET" Value="ASP.NET" />
                <asp:ListItem Text="React" Value="React" />
                <asp:ListItem Text="Node.js" Value="Node.js" />
                <asp:ListItem Text="SQL" Value="SQL" />
            </asp:CheckBoxList>
            <br />

            <asp:Button ID="btnSubmit" runat="server" Text="Submit Survey" OnClick="btnSubmit_Click" />
            
            <asp:Label ID="lblThankYou" runat="server" ForeColor="Green" />
            <br />
            <asp:Label ID="lblSurveyResults" runat="server" ForeColor="Blue" />
        </div>
    </form>
</body>
</html>
