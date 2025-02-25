<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Validation.aspx.cs" Inherits="Validation.Validation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.7.1/jquery.min.js"></script>
    <title>Registration Form</title>
</head>
<body>
    <form id="form2" runat="server">
        <div>
            <label for="TextBox1">Name:</label>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="Name is required." Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="Name cannot contain numbers." ValidationExpression="^[a-zA-Z\s]+$" Display="Dynamic"></asp:RegularExpressionValidator>
        </div>
        <div>
            <label for="TextBox3">Email:</label>
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox3" ErrorMessage="Email is required." Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TextBox3" ErrorMessage="Invalid email format." ValidationExpression="^[^\s@]+@[^\s@]+\.[^\s@]+$" Display="Dynamic"></asp:RegularExpressionValidator>
        </div>
        <div>
            <label for="TextBox2">Mobile No:</label>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox2" ErrorMessage="Mobile number is required." Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="TextBox2" ErrorMessage="Invalid mobile number format." ValidationExpression="^[6-9]\d{9}$" Display="Dynamic"></asp:RegularExpressionValidator>
        </div>
        <div>
            <label for="DropDownList1">Country:</label>
            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true">
                <asp:ListItem Text="Select" Value="Select"></asp:ListItem>
                <asp:ListItem Text="India" Value="India"></asp:ListItem>
                <asp:ListItem Text="USA" Value="USA"></asp:ListItem>
                <asp:ListItem Text="Canada" Value="Canada"></asp:ListItem>
                <asp:ListItem Text="United Kingdom" Value="UK"></asp:ListItem>
                <asp:ListItem Text="Germany" Value="Germany"></asp:ListItem>
                <asp:ListItem Text="Japan" Value="Japan"></asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="rfvCountry" runat="server" ControlToValidate="DropDownList1" InitialValue="Select" ErrorMessage="Please select a country." Display="Dynamic" ForeColor="Red" />
        </div>
        <div>
            <label for="DropDownList2">State:</label>
            <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged"></asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="DropDownList2" InitialValue="Select" ErrorMessage="Please select a state." Display="Dynamic"></asp:RequiredFieldValidator>
        </div>
        <div>
            <label for="DropDownList3">City:</label>
            <asp:DropDownList ID="DropDownList3" runat="server"></asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="DropDownList3" InitialValue="Select" ErrorMessage="Please select a city." Display="Dynamic"></asp:RequiredFieldValidator>
        </div>
        <div>
            <label for="TextBox4">Address:</label>
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TextBox4" ErrorMessage="Address is required." Display="Dynamic"></asp:RequiredFieldValidator>
        </div>
        <div>
            <label for="TextBox5">Password:</label>
            <asp:TextBox ID="TextBox5" runat="server" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="TextBox5" ErrorMessage="Password is required." Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="TextBox5" ErrorMessage="Password must be at least 8 characters long, contain at least one capital letter, and one numeric value." ValidationExpression="^(?=.*[A-Z])(?=.*\d).{8,}$" Display="Dynamic"></asp:RegularExpressionValidator>
        </div>
        <div>
            <label for="TextBox6">Confirm Password:</label>
            <asp:TextBox ID="TextBox6" runat="server" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="TextBox6" ErrorMessage="Confirm Password is required." Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="TextBox6" ControlToCompare="TextBox5" ErrorMessage="Passwords do not match." Display="Dynamic"></asp:CompareValidator>
        </div>
        <div>
            <label>Certificates:</label>
            <asp:CheckBoxList ID="CheckBoxList1" runat="server">
                <asp:ListItem Text="Java Certification" Value="JavaCertification"></asp:ListItem>
                <asp:ListItem Text="Python Programming Certificate" Value="PythonProgrammingCertificate"></asp:ListItem>
                <asp:ListItem Text="Data Science Certificate" Value="DataScienceCertificate"></asp:ListItem>
                <asp:ListItem Text="Project Management Professional (PMP)" Value="PMP"></asp:ListItem>
                <asp:ListItem Text="Certified Ethical Hacker (CEH)" Value="CEH"></asp:ListItem>
                <asp:ListItem Text="AWS Certified Solutions Architect" Value="AWSArchitect"></asp:ListItem>
                <asp:ListItem Text="Microsoft Azure Fundamentals" Value="AzureFundamentals"></asp:ListItem>
                <asp:ListItem Text="Machine Learning Certificate" Value="MachineLearningCertificate"></asp:ListItem>
            </asp:CheckBoxList>
        </div>
        <div>
            <label>Gender:</label>
            <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
                <asp:ListItem Text="Other" Value="Other"></asp:ListItem>
            </asp:RadioButtonList>
        </div>
        <div>
            <asp:Button ID="Button2" runat="server" Text="Register" OnClick="Button1_Click" />
        </div>
        <div>
            <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
