<%@ Page Language="C#" AutoEventWireup="true" CodeFile="joins.aspx.cs" Inherits="joins" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Database Joins</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="btnInnerJoin" runat="server" Text="Inner Join" OnClick="btnInnerJoin_Click" />
            <asp:GridView ID="GridViewInnerJoin" runat="server"></asp:GridView>
        </div>
        <br />
        <br />
        <div>
            <asp:Button ID="btnLeftJoin" runat="server" Text="Left Join" OnClick="btnLeftJoin_Click" />
            <asp:GridView ID="GridViewLeftJoin" runat="server"></asp:GridView>
        </div>
        <br />
        <br />
        <div>
            <asp:Button ID="btnRightJoin" runat="server" Text="Right Join" OnClick="btnRightJoin_Click"  Enabled="false" />
            <asp:GridView ID="GridViewRightJoin" runat="server"></asp:GridView>
        </div>
        <br />
        <br />
        <div>
            <asp:Button ID="btnOuterJoin" runat="server" Text="Outer Join" OnClick="btnOuterJoin_Click"  Enabled="false"/>
            <asp:GridView ID="GridViewOuterJoin" runat="server"></asp:GridView>
        </div>
        <br />
        <br />
        <div>
            <asp:Button ID="btnCrossJoin" runat="server" Text="Cross Join" OnClick="btnCrossJoin_Click" />
            <asp:GridView ID="GridView1" runat="server"></asp:GridView>
        </div>
    </form>
</body>
</html>
