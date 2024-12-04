<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cal1.aspx.cs" Inherits="Calendar_Control.Cal1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>Defult start with sunday:<br />
            <div>
                <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged" OnDayRender="Calendar1_DayRender"></asp:Calendar>
            </div>
            <br />
            <br />
            <div>
                <asp:Label ID="Label2" runat="server"></asp:Label>
            </div>
            <div>
                <asp:Label ID="Label3" runat="server"></asp:Label>
            </div>
            <div>
                <asp:Label ID="Label4" runat="server"></asp:Label>
            </div>
            <div>
                <asp:Label ID="Label5" runat="server"></asp:Label>
            </div>
        </div>
        <br />
        <br />
        <br />
        <br />
        <div>
            <div>
                <asp:Calendar ID="Calendar2" runat="server" FirstDayOfWeek="Monday" OnDayRender="Calendar2_DayRender"></asp:Calendar>
            </div>
        </div>
        <br />
        <br />
        <br />
        <br />
        <div>
            <div>
                <asp:Calendar ID="Calendar3" runat="server" FirstDayOfWeek="Monday" OnDayRender="Calendar3_DayRender" OnVisibleMonthChanged="Calendar3_VisibleMonthChanged"></asp:Calendar>
            </div>
        </div>
    </form>
</body>
</html>
