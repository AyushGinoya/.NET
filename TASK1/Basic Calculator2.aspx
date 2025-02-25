<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Basic Calculator2.aspx.cs" Inherits="Basic_Calculator2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:TextBox ID="txtNumber1" runat="server" Width="150px"></asp:TextBox>
            <br />
            <br />
            <asp:TextBox ID="txtNumber2" runat="server" Width="150px"></asp:TextBox>
            <br />
            <br />
            <br />
            <asp:DropDownList ID="ddlOperations" runat="server">
                <asp:ListItem Text="Select Operation" Value="" />
                <asp:ListItem Text="Add" Value="add" />
                <asp:ListItem Text="Subtract" Value="subtract" />
                <asp:ListItem Text="Multiply" Value="multiply" />
                <asp:ListItem Text="Divide" Value="divide" />
                <asp:ListItem Text="Modulo" Value="modulo" />
            </asp:DropDownList>
            <br />
            <br />
            <br />
            <asp:Button ID="btnCalculate" runat="server" Text="Calculate" OnClick="btnCalculate_Click" />
            <br />
            <br />
            <br />
            <br />
            <asp:Label ID="lblResult" runat="server" Text="Result: " Font-Bold="True" ForeColor="Blue" />
        </div>
    </form>
</body>
</html>
