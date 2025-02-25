<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.Master" AutoEventWireup="true" CodeBehind="ContactCategory.aspx.cs" Inherits="GN_masterpage.AdminPanel.ContactCategory.ContactCategory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" runat="server">
    <h3>List Of ContactCategory</h3>
<asp:GridView ID="gvCountry" runat="server"></asp:GridView>
</asp:Content>
