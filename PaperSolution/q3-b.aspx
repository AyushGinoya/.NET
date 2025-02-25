<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="q3-b.aspx.cs" Inherits="PaperSolution.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="l2" runat="server" Text="Name"></asp:Label>
            <asp:TextBox ID="name1" runat="server"></asp:TextBox>
            </br>
            <asp:Label ID="l1" runat="server" Text="Enrollment"></asp:Label>
            <asp:TextBox ID="enr" runat="server"></asp:TextBox>
            </br>
            <asp:Label ID="L3" runat="server" Text="Upload Resume"></asp:Label>
            <asp:FileUpload ID="resume" runat="server" />
            </br>
            </br>
            <asp:Button ID="btn" runat="server" Text="submit" OnClick="btn_Click" />
            </br>
            </br>
             <asp:Label ID="Label1" runat="server" ></asp:Label>
            </br>
             <asp:Label ID="Label2" runat="server" ></asp:Label>
             </br>
            <asp:Label ID="Label3" runat="server" ></asp:Label>
        </div>
    </form>
</body>
</html>
