<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.Master" AutoEventWireup="true" CodeBehind="CCategoryDelete.aspx.cs" Inherits="GN_masterpage.AdminPanel.ContactCategory.CCategoryDelete" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" runat="server">
    <h3>List Of ContactCategory</h3>
    <br />
    <br />
    <asp:HyperLink ID="hlAddState" runat="server" Text="Add New Country"
        NavigateUrl="~/AdminPanel/ContactCategory/ContactCategoryAddEdit.aspx" Visible="true">
    </asp:HyperLink>
    <br />
    <asp:GridView ID="gvCC" runat="server" OnRowCommand="gvCC_RowCommand" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="ContactCategoryID" HeaderText="ID" />
            <asp:BoundField DataField="ContactCategoryName" HeaderText="Code" />
            <asp:BoundField DataField="CreationDate" HeaderText="Date" />
            <asp:TemplateField HeaderText="Delete">
                <ItemTemplate>
                    <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandName="DeleteRow" CommandArgument='<%# Eval("ContactCategoryID").ToString().Trim() %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Edit">
                <ItemTemplate>
                    <asp:HyperLink ID="hlAddCC" runat="server" NavigateUrl='<%#"~/AdminPanel/ContactCategory/ContactCategoryAddEdit.aspx?ContactCategoryId="+Eval("ContactCategoryID").ToString().Trim() %>'>Edit</asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
     <br />
 <br />
 <asp:Label ID="txt" runat="server"></asp:Label>
</asp:Content>
