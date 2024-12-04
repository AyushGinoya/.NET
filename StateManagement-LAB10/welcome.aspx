<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="welcome.aspx.cs" Inherits="StateManagement_LAB10.welcome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <br /><br />
        User Name:-<asp:Label id="user1" runat="server"/>
        <br /><br /><br />
        User Name:-<asp:Label id="pwd" runat="server"/>
<br /><br /><br />
        <asp:Button ID="edit" runat="server" Text="Edit Profile" OnClick="edit_Click" /><br /><br />
        <asp:Button ID="logout" runat="server" Text="Logout" OnClick="logout_Click" /><br /><br />
        <asp:Button ID="cpwd" runat="server" Text="Change Password" OnClick="cpwd_Click" /><br /><br />
    </form>
</body>
</html>
