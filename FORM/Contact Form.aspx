<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Contact Form.aspx.cs" Inherits="Contact_Form" %>

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
                <asp:TextBox ID="txtName" runat="server" Width="300px"></asp:TextBox>
                <asp:RequiredFieldValidator
                    ID="rfvName"
                    runat="server"
                    ControlToValidate="txtName"
                    ErrorMessage="Name is required."
                    ForeColor="Red"
                    Display="Dynamic" />
                <br />

                <asp:Label ID="lblEmail" runat="server" Text="Email: " />
                <asp:TextBox ID="txtEmail" runat="server" Width="300px"></asp:TextBox>
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

                <asp:Label ID="lblMessage" runat="server" Text="Message: " />
                <asp:TextBox ID="txtMessage" runat="server" TextMode="MultiLine" Width="300px" Height="70px"></asp:TextBox>
                <asp:RequiredFieldValidator
                    ID="rfvMessage"
                    runat="server"
                    ControlToValidate="txtMessage"
                    ErrorMessage="Message is required."
                    ForeColor="Red"
                    Display="Dynamic" />
                <br />

                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />


                <asp:Label ID="lblThankYou" runat="server" ForeColor="Green" />
            </div>
        </div>
    </form>
</body>
</html>
