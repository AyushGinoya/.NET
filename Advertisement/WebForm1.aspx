<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Advertisement.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:AdRotator ID="AdRotator1" runat="server" AdvertisementFile="~/XMLFile1.xml" Target="_blank" KeywordFilter="Trip" />
            <asp:AdRotator ID="AdRotator2" runat="server" AdvertisementFile="~/XMLFile1.xml" Target="_blank" KeywordFilter="Navratri" />
        </div>
    </form>
</body>
</html>
