<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="File_Upload.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:FileUpload ID="FileUpload1" runat="server" /> &nbsp; &nbsp; &nbsp
            <asp:Button ID="Button1" runat="server" Text="Upload" OnClick="Button1_Click"/>
        </div>
    </form>
</body>
</html>
