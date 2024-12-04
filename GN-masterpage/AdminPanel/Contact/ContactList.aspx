<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.Master" AutoEventWireup="true" CodeBehind="ContactList.aspx.cs" Inherits="GN_masterpage.AdminPanel.Contact.ContactList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" runat="server">
    <h3>List Of Contact</h3>
    <asp:GridView ID="gvCountry" runat="server"></asp:GridView>
</asp:Content>
