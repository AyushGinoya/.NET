<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebService_Clint.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Employee Details</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            
            <asp:Label ID="Label1" runat="server" Text="Enter Employee ID:"></asp:Label>
            <asp:TextBox ID="txtEmployeeID" runat="server"></asp:TextBox>

            <asp:Button ID="btnGetDetails" runat="server" Text="Get Details" OnClick="btnGetDetails_Click" />

            <asp:GridView ID="gvEmployeeDetails" runat="server" AutoGenerateColumns="True" />
        </div>
    </form>
</body>
</html>
