<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CommandCalculator.aspx.cs" Inherits="CommandCalculator.CommandCalculator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="num1" runat="server"></asp:TextBox> <br/><br/>
            <asp:TextBox ID="num2" runat="server"></asp:TextBox> <br/><br/>
            <asp:TextBox ID="result" runat="server" Enabled="false"></asp:TextBox> <br/><br/>

            <asp:Button ID="add" runat="server" Text="Add" CommandName="math" CommandArgument="add" OnCommand="Calculation"/>&nbsp; &nbsp
            <asp:Button ID="sub" runat="server" Text="Sub" CommandName="math" CommandArgument="sub" OnCommand="Calculation"/>&nbsp; &nbsp
            <asp:Button ID="mul" runat="server" Text="Mul" CommandName="math" CommandArgument="mul" OnCommand="Calculation"/>&nbsp; &nbsp
            <asp:Button ID="div" runat="server" Text="Div" CommandName="math" CommandArgument="div" OnCommand="Calculation"/><br/><br/>

            <asp:Button ID="clr" runat="server" Text="Clear" CommandName="clr" OnCommand="Calculation"/>
        </div>
    </form>
</body>
</html>
