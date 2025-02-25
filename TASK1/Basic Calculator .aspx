<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Basic Calculator .aspx.cs" Inherits="Basic_Calculator_" %>

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

            <asp:TextBox ID="txtNumber2" runat="server" Width="150px"></asp:TextBox>
            <br />
            <br />

            <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
            <asp:Button ID="btnSubtract" runat="server" Text="Subtract" OnClick="btnSubtract_Click" />
            <asp:Button ID="btnMultiply" runat="server" Text="Multiply" OnClick="btnMultiply_Click" />
            <asp:Button ID="btnDivide" runat="server" Text="Divide" OnClick="btnDivide_Click" />
            <asp:Button ID="btnModulo" runat="server" Text="Modulo" OnClick="btnModulo_Click" />
            <br />
            <br />
            <asp:Label ID="lblResult" runat="server" Text="Result: " Font-Bold="True" ForeColor="Blue" />
        </div>
    </form>
</body>
</html>
