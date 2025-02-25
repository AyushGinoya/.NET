<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
     <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblUsername" runat="server" Text="Username: " />
            <asp:TextBox ID="txtUsername" runat="server" Width="200px"></asp:TextBox>
            <asp:RequiredFieldValidator
                ID="rfvUsername"
                runat="server"
                ControlToValidate="txtUsername"
                ErrorMessage="Username is required."
                ForeColor="Red"
                Display="Dynamic" />
            <br />

            <asp:Label ID="lblPassword" runat="server" Text="Password: " />
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="200px"></asp:TextBox>
            <asp:RequiredFieldValidator
                ID="rfvPassword"
                runat="server"
                ControlToValidate="txtPassword"
                ErrorMessage="Password is required."
                ForeColor="Red"
                Display="Dynamic" />
            <br />

            <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
            
            <asp:Label ID="lblMessage" runat="server" ForeColor="Green" />
        </div>
    </form>
</body>
</html>
