<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Form.aspx.cs" Inherits="Validation_Controls.Form" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registration Form</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Name: 
            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="reqName" runat="server" ForeColor="Red"
                ControlToValidate="txtName" ErrorMessage="Enter your Name" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="regName" runat="server" ForeColor="Red"
                ControlToValidate="txtName" ErrorMessage="Name cannot contain numbers."
                ValidationExpression="^[a-zA-Z\s]+$" Display="Dynamic"></asp:RegularExpressionValidator>
        </div>

        <br />
        <div>
            Email: 
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="reqEmail" runat="server" ForeColor="Red"
                ControlToValidate="txtEmail" ErrorMessage="Enter your Email" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="regEmail" runat="server" ForeColor="Red"
                ControlToValidate="txtEmail" ErrorMessage="Invalid email format."
                ValidationExpression="^[^\s@]+@[^\s@]+\.[^\s@]+$" Display="Dynamic"></asp:RegularExpressionValidator>
        </div>

        <br />
        <div>
            Mobile No.: 
            <asp:TextBox ID="txtMobileNo" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="reqMobileNo" runat="server" ForeColor="Red"
                ControlToValidate="txtMobileNo" ErrorMessage="Enter Mobile No" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="regMobileNo" runat="server" ForeColor="Red"
                ControlToValidate="txtMobileNo" ErrorMessage="Invalid mobile number format."
                ValidationExpression="^[6-9]\d{9}$" Display="Dynamic"></asp:RegularExpressionValidator>
        </div>

        <br />
        <div>
            Address: 
            <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="reqAddress" runat="server" ForeColor="Red"
                ControlToValidate="txtAddress" ErrorMessage="Enter your Address" Display="Dynamic"></asp:RequiredFieldValidator>
        </div>

        <br />
        <div>
            Password: 
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="reqPassword" runat="server" ForeColor="Red"
                ControlToValidate="txtPassword" ErrorMessage="Enter your Password" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="regPassword" ForeColor="Red" runat="server"
                ControlToValidate="txtPassword" ErrorMessage="Password must be at least 8 characters, contain one capital letter, and one number."
                ValidationExpression="^(?=.*[A-Z])(?=.*\d).{8,}$" Display="Dynamic"></asp:RegularExpressionValidator>
        </div>

        <br />
        <div>
            Confirm Password: 
            <asp:TextBox ID="txtConfPassword" runat="server" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="reqConfPassword" runat="server" ForeColor="Red"
                ControlToValidate="txtConfPassword" ErrorMessage="Confirm your Password" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="compConfPassword" runat="server" ForeColor="Red"
                ControlToValidate="txtConfPassword" ControlToCompare="txtPassword"
                ErrorMessage="Passwords do not match." Display="Dynamic"></asp:CompareValidator>
        </div>

        <br />
        <div>
            <asp:DropDownList ID="ddlCountry" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged">
                <asp:ListItem Text="Select Country" Value=""></asp:ListItem>
                <asp:ListItem Text="India" Value="India"></asp:ListItem>
                <asp:ListItem Text="USA" Value="USA"></asp:ListItem>
                <asp:ListItem Text="Canada" Value="Canada"></asp:ListItem>
                <asp:ListItem Text="United Kingdom" Value="UK"></asp:ListItem>
                <asp:ListItem Text="Germany" Value="Germany"></asp:ListItem>
                <asp:ListItem Text="Japan" Value="Japan"></asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="reqddlCountry" runat="server" ForeColor="Red"
                ControlToValidate="ddlCountry" InitialValue="" ErrorMessage="Please select a country." Display="Dynamic"></asp:RequiredFieldValidator>
        </div>

        <br />
        <div>
            <asp:DropDownList ID="ddlState" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlState_SelectedIndexChanged">
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="reqddlState" runat="server"
                ControlToValidate="ddlState" InitialValue="" ErrorMessage="Please select a state." Display="Dynamic"></asp:RequiredFieldValidator>
        </div>

        <br />
        <div>
            <asp:DropDownList ID="ddlCity" runat="server" AutoPostBack="true">
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="reqddlCity" runat="server"
                ControlToValidate="ddlCity" InitialValue="" ErrorMessage="Please select a city." Display="Dynamic"></asp:RequiredFieldValidator>
        </div>

        <br />
        <br />

        <div>
            <label>Certificates:</label>
            <asp:CheckBoxList ID="cblCertificates" runat="server">
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
        <br />
        <div>
            <label>Gender:</label>
            <asp:RadioButtonList ID="rblGender" runat="server">
                <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
                <asp:ListItem Text="Other" Value="Other"></asp:ListItem>
            </asp:RadioButtonList>

        </div>
        <br />
        <div>
            <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="Button2_Click" />
        </div>
    </form>
</body>
</html>
