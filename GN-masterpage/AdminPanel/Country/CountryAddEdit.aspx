<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.Master" AutoEventWireup="true" CodeBehind="CountryAddEdit.aspx.cs" Inherits="GN_masterpage.AdminPanel.Country.CountryAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" runat="server">
    <h2>Add Country</h2>
    Country Name:<asp:TextBox runat="server" ID="Cname"></asp:TextBox></br></br>
    Country Code:<asp:TextBox runat="server" ID="Ccode"></asp:TextBox></br></br>
    <asp:Button ID="save" runat="server" Text="Save" OnClick="save_Click" /></br></br>
    <asp:Label ID="txt" runat="server"></asp:Label></br></br>
    <asp:DropDownList ID="ddlCountryID" runat="server"></asp:DropDownList>&nbsp;&nbsp;&nbsp;
    <asp:DropDownList ID="ddlStateID" runat="server"></asp:DropDownList>
</asp:Content>
