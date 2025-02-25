<%@ Page Language="C#" AutoEventWireup="true" CodeFile="crud.aspx.cs" Inherits="crud" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Student LINQ CRUD Operations</h2>
            Student ID :
    <asp:TextBox ID="txtStudentId" runat="server" Placeholder="Student ID" /><br />
            <br />
            Student Name :
    <asp:TextBox ID="txtStudentName" runat="server" Placeholder="Student Name" /><br />
            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Enter Name" ControlToValidate="txtStudentName" Display="Dynamic"></asp:RequiredFieldValidator>
    <asp:regularexpressionvalidator id="regularexpressionvalidator1" runat="server" controltovalidate="txtstudentname" errormessage="name not contain integer" validationexpression="^[a-za-z\s]+$"  display="dynamic"></asp:regularexpressionvalidator>--%>
            <br />
            Student Cpi :
    <asp:TextBox ID="txtStudentCPI" runat="server" Placeholder="Student Cpi" /><br />
            <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Enter CPI" ControlToValidate="txtStudentCPI" Display="Dynamic"></asp:RequiredFieldValidator>"
    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"  ControlToValidate="txtStudentCPI" ErrorMessage="Enter valid CPI" ValidationExpression="^(10(\.0+)?|[0-9](\.[0-9]+)?)$" Display="Dynamic"></asp:RegularExpressionValidator>--%>
            <br />

            <asp:Button ID="btnCreate" runat="server" Text="Create" OnClick="btnCreate_Click" />
            &nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnRead" runat="server" Text="Read" OnClick="btnRead_Click" />
            &nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
            &nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
        </div>
        <br />
        <br />
        <br />
        <br />
        <asp:Label ID="Label1" runat="server"></asp:Label>
        <br />
        <br />
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server"></asp:GridView>
    </form>
</body>
</html>
