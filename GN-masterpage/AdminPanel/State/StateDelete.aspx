<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.Master" AutoEventWireup="true" CodeBehind="StateDelete.aspx.cs" Inherits="GN_masterpage.AdminPanel.State.StateDelete" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" runat="server">
    <h3>List Of State</h3>
    <br />
    <br />
    <asp:HyperLink ID="hlAddState" runat="server" Text="Add New State"
        NavigateUrl="~/AdminPanel/State/StateAddEdit.aspx" Visible="true">
    </asp:HyperLink>
    <br />
    <br />
    <asp:GridView ID="gvCountry" runat="server" AutoGenerateColumns="false" OnRowCommand="gvCountry_RowCommand">
        <Columns>
            <asp:BoundField DataField="StateId" HeaderText="ID" />
            <asp:BoundField DataField="CountryId" HeaderText="CID" />
            <asp:BoundField DataField="StateName" HeaderText="Name" />
            <asp:BoundField DataField="StateCode" HeaderText="Code" />
            <asp:TemplateField HeaderText="Delete">
                <ItemTemplate>
                    <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandName="DeleteRow" CommandArgument='<%# Eval("StateId").ToString() %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Edit">
                <ItemTemplate>
                    <asp:HyperLink Text="Edit" Visible="true" runat="server" ID="hlEdit" NavigateUrl='<%# "~/AdminPanel/State/StateAddEdit.aspx?StateId=" + Eval("StateId").ToString().Trim() %>'>
                    </asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <asp:Label ID="txt" runat="server"></asp:Label>
</asp:Content>
