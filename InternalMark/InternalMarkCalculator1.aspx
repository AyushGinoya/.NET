<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InternalMarkCalculator1.aspx.cs" Inherits="InternalMarkCalculator1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Internal Mark Calculator</h2>
            <label for="ddlCollegeId">Select College Name:</label>
            <asp:DropDownList ID="ddlCollegeId" runat="server">
            </asp:DropDownList>
            &nbsp;&nbsp;&nbsp
              <label for="ddlCollegeId">Select College Semester:</label>
            <asp:DropDownList ID="ddlSemesterID" runat="server">
            </asp:DropDownList>
            &nbsp;&nbsp;&nbsp
              <label for="ddlCollegeId">Select College Year:</label>
            <asp:DropDownList ID="ddlYear" runat="server">
            </asp:DropDownList>
            &nbsp;&nbsp;&nbsp
              <label for="ddlCollegeId">Select Branch:</label>
            <asp:DropDownList ID="ddlBranch" runat="server">
            </asp:DropDownList>
            &nbsp;&nbsp;&nbsp
            <label for="txtCalculationMethod">Enter Calculation Method:</label>
            <asp:TextBox ID="txtCalculationMethod" runat="server" Width="300px"
                PlaceHolder="(mid1+mid2)/2 + mid3 + Assignment"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblResult" runat="server" Text="" Font-Bold="true" ForeColor="Blue"></asp:Label>
            <br />
            <asp:Button ID="btnCalculate" runat="server" Text="Calculate"
                OnClick="btnCalculate_Click" />
            <br />
            <br />

            <h2>Subject-Wise Marks</h2>
            <asp:GridView ID="gvSubjectMarks" runat="server" AutoGenerateColumns="True" CssClass="table" />

            <%--            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <!-- Column for Student Name -->
                    <asp:BoundField DataField="StudentName" HeaderText="Student Name" />

                    <!-- Column with 3 Sub-Columns -->
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <table style="width: 100%; text-align: center;">
                                <tr>
                                    <th colspan="3">Subject 1</th>
                                </tr>
                                <tr>
                                    <th>Mid 1</th>
                                    <th>Mid 2</th>
                                    <th>Mid 3</th>
                                    <th>Attendance</th>
                                    <th>Assignment</th>
                                </tr>
                            </table>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <table style="width: 100%; text-align: center;">
                                <tr>
                                    <td><%# Eval("mid1") %></td>
                                    <td><%# Eval("mid2") %></td>
                                    <td><%# Eval("mid3") %></td>
                                    <td><%# Eval("Attendance") %></td>
                                    <td><%# Eval("Assignment") %></td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>--%>


            <h2>Field Weightages</h2>
            <asp:GridView ID="gvFieldWeightage" runat="server" AutoGenerateColumns="True" CssClass="table" />

            <h2>Student Data</h2>
            <asp:GridView ID="gvStudent" runat="server" AutoGenerateColumns="True" CssClass="table" />

            <h2>Subject Data</h2>
            <asp:GridView ID="gvSubject" runat="server" AutoGenerateColumns="True" CssClass="table" />

            <h2>Collage Data</h2>
            <asp:GridView ID="gvCollage" runat="server" AutoGenerateColumns="True" CssClass="table" />
        </div>
    </form>
</body>
</html>
