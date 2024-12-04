<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="edit.aspx.cs" Inherits="StateManagement_LAB10.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Old Username :
            <asp:TextBox ID="olduser" runat="server"></asp:TextBox>
            <br />
            <br />
            New Username <asp:TextBox ID="newuser" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="save" runat="server" Text="Save" OnClick="save_Click" />
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Back" OnClick="back_Click" />
        </div>
    </form>
</body>
</html>
