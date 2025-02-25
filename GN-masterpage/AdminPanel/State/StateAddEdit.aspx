<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.Master" AutoEventWireup="true" CodeBehind="StateAddEdit.aspx.cs" Inherits="GN_masterpage.AdminPanel.State.StateAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" runat="server">
    <h2>Add State</h2>
    Country ID :
    <asp:DropDownList ID="ddlCountryID" runat="server"></asp:DropDownList><br />
    <br />
    State Name:<asp:TextBox runat="server" ID="Sname"></asp:TextBox><br />
    <br />
    State Code:<asp:TextBox runat="server" ID="Scode"></asp:TextBox><br />
    <br />
    <asp:Button ID="save" runat="server" Text="Save" OnClick="save_Click" /><br />
    <br />
    <asp:Button ID="btnCancle" runat="server" Text="Cancle" OnClick="btnCancle_Click" BackColor="Red"/><br />
    <br />
    <asp:Label ID="txt" runat="server"></asp:Label><br />
    <br />
</asp:Content>
