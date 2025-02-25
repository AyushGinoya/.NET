<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <asp:Label ID="lblName" runat="server" Text="Name: " />
                <asp:TextBox ID="txtName" runat="server" Width="200px"></asp:TextBox>
                <asp:RequiredFieldValidator
                    ID="rfvName"
                    runat="server"
                    ControlToValidate="txtName"
                    ErrorMessage="Name is required."
                    ForeColor="Red"
                    Display="Dynamic" />
                <br />

                <asp:Label ID="lblEmail" runat="server" Text="Email: " />
                <asp:TextBox ID="txtEmail" runat="server" Width="200px"></asp:TextBox>
                <asp:RequiredFieldValidator
                    ID="rfvEmail"
                    runat="server"
                    ControlToValidate="txtEmail"
                    ErrorMessage="Email is required."
                    ForeColor="Red"
                    Display="Dynamic" />
                <asp:RegularExpressionValidator
                    ID="revEmail"
                    runat="server"
                    ControlToValidate="txtEmail"
                    ValidationExpression="^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]{2,7}$"
                    ErrorMessage="Invalid email format."
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
                <asp:Button ID="btnSubmit" runat="server" Text="Register" OnClick="btnSubmit_Click" />

                <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Green"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
