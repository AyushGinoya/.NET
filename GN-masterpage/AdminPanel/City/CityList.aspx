<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.Master" AutoEventWireup="true" CodeBehind="CityList.aspx.cs" Inherits="GN_masterpage.AdminPanel.City.CityList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" runat="server">
    <h3>List Of City</h3>
<asp:GridView ID="gvCountry" runat="server"></asp:GridView>
</asp:Content>
