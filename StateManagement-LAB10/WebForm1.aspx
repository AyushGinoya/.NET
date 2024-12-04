<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="StateManagement_LAB10.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            Username : <asp:TextBox ID="username" runat="server"></asp:TextBox><br /><br />
            Password : <asp:TextBox ID="password" runat="server"></asp:TextBox><br /><br />
            <asp:Button ID="login" runat="server" Text="Login" OnClick="login_Click" />
        </div>
    </form>
</body>
</html>
