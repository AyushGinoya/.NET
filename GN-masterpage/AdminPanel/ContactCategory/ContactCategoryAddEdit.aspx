<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.Master" AutoEventWireup="true" CodeBehind="ContactCategoryAddEdit.aspx.cs" Inherits="GN_masterpage.AdminPanel.ContactCategory.ContactCategoryAddEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" runat="server">
    <h2>Add ContactCategory</h2>
    ContactCategory Name:<asp:TextBox runat="server" ID="CCname"></asp:TextBox></br></br>
    <asp:Button ID="save" runat="server" Text="Save" OnClick="save_Click" /></br></br>
    <asp:Label ID="txt" runat="server"></asp:Label></br></br>
</asp:Content>
