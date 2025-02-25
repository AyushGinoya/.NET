<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="changepwd.aspx.cs" Inherits="StateManagement_LAB10.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Old Password :
            <asp:TextBox ID="oldpwd" runat="server"></asp:TextBox>
            <br />
            <br />
            New Password<asp:TextBox ID="newpwd" runat="server"></asp:TextBox>
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
