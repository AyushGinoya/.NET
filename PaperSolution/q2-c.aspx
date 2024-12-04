<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="q2-c.aspx.cs" Inherits="PaperSolution.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>  
    <form id="form1" runat="server">
        <div>
            <asp:DropDownList ID="Rows" runat="server">
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
                <asp:ListItem>5</asp:ListItem>
            </asp:DropDownList>
            </br>
            </br>
            </br>
            <asp:DropDownList ID="Columns" runat="server">
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
                <asp:ListItem>5</asp:ListItem>
            </asp:DropDownList>
            </br>
            </br>
            </br>
            <asp:RadioButtonList ID="Type" runat="server">
                <asp:ListItem>TextBox</asp:ListItem>
                <asp:ListItem>HyperLink</asp:ListItem>
                <asp:ListItem>LinkButton</asp:ListItem>
            </asp:RadioButtonList>
            <asp:Button ID="btn" Text="create Table" runat="server" OnClick="btn_Click" />

            <panel id="table" runat="server"></panel>
        </div>
    </form>
</body>
</html>
