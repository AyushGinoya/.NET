<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="orq3-b.aspx.cs" Inherits="PaperSolution.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:CheckBoxList ID="List" runat="server">
                <asp:ListItem Value="20">Item 1</asp:ListItem>
                <asp:ListItem Value="30">Item 2</asp:ListItem>
                <asp:ListItem Value="40">Item 3</asp:ListItem>
                <asp:ListItem Value="56">Item 4</asp:ListItem>
                <asp:ListItem Value="156">Item 5</asp:ListItem>
                <asp:ListItem Value="536">Item 6</asp:ListItem>
                <asp:ListItem Value="5446">Item 7</asp:ListItem>
            </asp:CheckBoxList>
            </br>
            </br>
            <asp:TextBox ID="Total" runat="server"></asp:TextBox>
            </br>
            </br>
            <asp:Button ID="Purchese" runat="server" Text="Purchese" OnClick="Purchese_Click" />
            </br>
            </br>
            <asp:Label ID="Display" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>

