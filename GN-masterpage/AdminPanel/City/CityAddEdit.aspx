<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.Master" AutoEventWireup="true" CodeBehind="CityAddEdit.aspx.cs" Inherits="GN_masterpage.AdminPanel.City.CityAddEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" runat="server">
    <h2>Add CIty</h2>

     State ID : <asp:DropDownList ID="ddlCityID" runat="server"></asp:DropDownList></br></br>
     City Name: <asp:TextBox runat="server" ID="cname"></asp:TextBox></br></br>
     PinCode: <asp:TextBox runat="server" ID="pincode"></asp:TextBox></br></br>
     STDCode : <asp:TextBox runat="server" ID="stdcode"></asp:TextBox></br></br>

    <asp:Button ID="save" runat="server" Text="Save" OnClick="save_Click" /></br></br>

    <asp:Label ID="txt" runat="server"></asp:Label></br></br>
</asp:Content>
