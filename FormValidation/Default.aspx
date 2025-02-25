<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>Enter Name</td>
                    <td>:<asp:TextBox ID="name" runat="server" placeholder="Enter Name"></asp:TextBox></td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="name" ErrorMessage="Name is required" ForeColor="Red" Display="Dynamic" ValidationGroup="FormValidation" />
                    </td>
                </tr>

                <tr>
                    <td>Enter Enrollment No.</td>
                    <td>:<asp:TextBox ID="enrollment" runat="server" placeholder="Enter Enrollment No"></asp:TextBox></td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvEnrollment" runat="server" ControlToValidate="enrollment" ErrorMessage="Enrollment number is required" ForeColor="Red" Display="Dynamic" ValidationGroup="FormValidation" />
                    </td>
                </tr>

                <tr>
                    <td>Enter Email-id</td>
                    <td>:<asp:TextBox ID="email" runat="server" placeholder="Enter Email-id"></asp:TextBox></td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="email" ErrorMessage="Email is required" ForeColor="Red" Display="Dynamic" ValidationGroup="FormValidation" />
                        <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="email" ValidationExpression="^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$" ErrorMessage="Invalid email format" ForeColor="Red" Display="Dynamic" ValidationGroup="FormValidation" />
                    </td>
                </tr>

                <tr>
                    <td>Enter Mobile No.</td>
                    <td>:<asp:TextBox ID="mobile" runat="server" placeholder="Enter Mobile No."></asp:TextBox></td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvMobile" runat="server" ControlToValidate="mobile" ErrorMessage="Mobile number is required" ForeColor="Red" Display="Dynamic" ValidationGroup="FormValidation" />
                        <asp:RegularExpressionValidator ID="revMobile" runat="server" ControlToValidate="mobile" ValidationExpression="^\d{10}$" ErrorMessage="Invalid mobile number (must be 10 digits)" ForeColor="Red" Display="Dynamic" ValidationGroup="FormValidation" />
                    </td>
                </tr>

                <tr>
                    <td>Enter Address</td>
                    <td>:<asp:TextBox ID="address" runat="server" TextMode="MultiLine" placeholder="Enter Address"></asp:TextBox></td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvAddress" runat="server" ControlToValidate="address" ErrorMessage="Address is required" ForeColor="Red" Display="Dynamic" ValidationGroup="FormValidation" />
                    </td>
                </tr>

                <tr>
                    <td>Enter Pincode</td>
                    <td>:<asp:TextBox ID="pincode" runat="server" placeholder="Enter Pincode"></asp:TextBox></td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvPincode" runat="server" ControlToValidate="pincode" ErrorMessage="Pincode is required" ForeColor="Red" Display="Dynamic" ValidationGroup="FormValidation" />
                        <asp:RegularExpressionValidator ID="revPincode" runat="server" ControlToValidate="pincode" ValidationExpression="^\d{6}$" ErrorMessage="Pincode must be 6 digits" ForeColor="Red" Display="Dynamic" ValidationGroup="FormValidation" />
                    </td>
                </tr>

                <tr>
                    <td>Select Student Country</td>
                    <td>:
                        <asp:DropDownList ID="ddlcountry" runat="server" OnSelectedIndexChanged="ddlcountry_SelectedIndexChanged" AutoPostBack="true">
                            <asp:ListItem Text="Select Country" Value="-1"></asp:ListItem>
                        </asp:DropDownList>
                        <span>
                            <asp:ImageButton ID="add" runat="server" ImageUrl="Images/plus.png" Width="15px" Height="15px" OnClick="addcountry_Click" />
                            <asp:ImageButton ID="refresh" runat="server" ImageUrl="Images/refresh-button.png" Width="15px" Height="15px" OnClick="refresh_Click" />
                        </span>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvCountry" runat="server" ControlToValidate="ddlcountry" InitialValue="-1" ErrorMessage="Country is required" ForeColor="Red" Display="Dynamic" ValidationGroup="FormValidation" />
                    </td>
                </tr>

                <tr>
                    <td>Select Student State</td>
                    <td>:
                        <asp:DropDownList ID="Dropstate" runat="server" OnSelectedIndexChanged="Dropstate_SelectedIndexChanged" AutoPostBack="True">
                            <asp:ListItem Text="Select State" Value="-1"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvState" runat="server" ControlToValidate="Dropstate" InitialValue="-1" ErrorMessage="State is required" ForeColor="Red" Display="Dynamic" ValidationGroup="FormValidation" />
                    </td>
                </tr>

                <tr>
                    <td>Select Student City</td>
                    <td>:
                        <asp:DropDownList ID="Dropcity" runat="server" OnSelectedIndexChanged="Dropcity_SelectedIndexChanged">
                            <asp:ListItem Text="Select City" Value="-1"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvCity" runat="server" ControlToValidate="Dropcity" InitialValue="-1" ErrorMessage="City is required" ForeColor="Red" Display="Dynamic" ValidationGroup="FormValidation" />
                    </td>
                </tr>

                <tr>
                    <td>Select Student Hobby</td>
                    <td>:<asp:CheckBoxList ID="hobby" runat="server">
                        <asp:ListItem Text="Chess" Value="Chess"></asp:ListItem>
                        <asp:ListItem Text="Cricket" Value="Cricket"></asp:ListItem>
                        <asp:ListItem Text="Movies" Value="Movies"></asp:ListItem>
                        <asp:ListItem Text="Reading" Value="Reading"></asp:ListItem>
                        <asp:ListItem Text="Coding" Value="Coding"></asp:ListItem>
                    </asp:CheckBoxList></td>
                </tr>

                <tr>
                    <td>Enter Password</td>
                    <td>:<asp:TextBox ID="password" runat="server" TextMode="Password" placeholder="Enter Password"></asp:TextBox></td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="password" ErrorMessage="Password is required" ForeColor="Red" Display="Dynamic" ValidationGroup="FormValidation" />
                    </td>
                </tr>

                <tr>
                    <td>Enter Confirm Password</td>
                    <td>:<asp:TextBox ID="cpassword" runat="server" TextMode="Password" placeholder="Enter Confirm-Password"></asp:TextBox></td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvCPassword" runat="server" ControlToValidate="cpassword" ErrorMessage="Confirm Password is required" ForeColor="Red" Display="Dynamic" ValidationGroup="FormValidation" />
                        <asp:CompareValidator ID="cvPassword" runat="server" ControlToValidate="cpassword" ControlToCompare="password" ErrorMessage="Passwords do not match" ForeColor="Red" Display="Dynamic" ValidationGroup="FormValidation" />
                    </td>
                </tr>

                <tr>
                    <td colspan="2">
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" ValidationGroup="FormValidation" />
                    </td>
                </tr>
            </table>

            <h3>Submitted Information:</h3>
            <asp:Label ID="lblResult" runat="server" Text=""></asp:Label>

        </div>
    </form>
</body>
</html>
