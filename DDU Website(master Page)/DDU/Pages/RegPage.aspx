<%@ Page Title="" Language="C#" MasterPageFile="~/DDU/Main.Master" AutoEventWireup="true" CodeBehind="RegPage.aspx.cs" Inherits="DDU_Website_master_Page_.DDU.Pages.RegPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cplMainPlaceHolder" runat="server">
    Name  :
    <asp:TextBox ID="name" runat="server"></asp:TextBox>

    <br />
    Email :
    <asp:TextBox ID="Email" runat="server"></asp:TextBox>
</asp:Content>
