<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.Master" AutoEventWireup="true" CodeBehind="CountryList.aspx.cs" Inherits="GN_masterpage.AdminPanel.Country.CountryList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" runat="server">
    <h3>List Of Country</h3>
    <asp:GridView ID="gvCountry" runat="server"></asp:GridView>
</asp:Content>
