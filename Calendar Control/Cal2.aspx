<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cal2.aspx.cs" Inherits="Calendar_Control.Cal2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <asp:Calendar ID="Calendar1" runat="server" FirstDayOfWeek="Monday" OnDayRender="Calendar1_DayRender"></asp:Calendar>
            </div>
        </div>
        <div>
            <div>
                <asp:Calendar ID="Calendar2" runat="server" FirstDayOfWeek="Monday" OnDayRender="Calendar2_DayRender"></asp:Calendar>
            </div>
        </div>
    </form>
</body>
</html>
