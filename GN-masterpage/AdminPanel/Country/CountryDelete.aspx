<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.Master" AutoEventWireup="true" CodeBehind="CountryDelete.aspx.cs" Inherits="GN_masterpage.AdminPanel.Country.CountryDelete" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" runat="server">
    <h3>List Of Country</h3>
    <br />
    <br />
    <asp:HyperLink ID="hlAddState" runat="server" Text="Add New Country"
        NavigateUrl="~/AdminPanel/Country/CountryAddEdit.aspx" Visible="true">
    </asp:HyperLink>
    <br />
    <br />
    <asp:GridView ID="gvCountry" runat="server" AutoGenerateColumns="false" OnRowCommand="gvCountry_RowCommand">
        <Columns>
            <asp:BoundField DataField="CountryID" HeaderText="ID" />
            <asp:BoundField DataField="CountryName" HeaderText="Name" />
            <asp:TemplateField HeaderText="Delete">
                <ItemTemplate>
                    <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandName="DeleteRow" CommandArgument='<%# Eval("CountryID").ToString() %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Edit">
                <ItemTemplate>
                    <asp:HyperLink
                        Text="Edit"
                        Visible="true"
                        runat="server"
                        ID="hlEdit"
                        NavigateUrl='<%# "~/AdminPanel/Country/CountryAddEdit.aspx?CountryID=" + Eval("CountryID").ToString().Trim() %>'>
                    </asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <br />
    <br />
    <asp:Label ID="txt" runat="server"></asp:Label>
</asp:Content>
