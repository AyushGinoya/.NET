<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.Master" AutoEventWireup="true" CodeBehind="StateList.aspx.cs" Inherits="GN_masterpage.AdminPanel.State.StateList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" runat="server">
        <h3>List Of State</h3>
<asp:GridView ID="gvCountry" runat="server" AutoGenerateColumns="false">
    <Columns>
         <asp:BoundField DataField="StateId" HeaderText="ID" />
         <asp:BoundField DataField="CountryId" HeaderText="CID" />
         <asp:BoundField DataField="StateName" HeaderText="Name" />
         <asp:BoundField DataField="StateCode" HeaderText="code" />
    </Columns>
</asp:GridView>
</asp:Content>
