<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="sessional2.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            ID:<asp:TextBox ID="id" runat="server"></asp:TextBox>

        </div>
        <p>
            Name:<asp:TextBox ID="name" runat="server"></asp:TextBox>
        </p>
        Salary:<asp:TextBox ID="salary" runat="server"></asp:TextBox>
        <p>
            <asp:Button ID="insert" runat="server" Text="Insert" OnClick="insert_Click" />
            <asp:Button ID="update" runat="server" Text="Update" />
            <asp:Button ID="delete" runat="server" Text="Delete" />
            <asp:Button ID="Avgsal" runat="server" Text="AvgSal" />
        </p>
    </form>
</body>
</html>
