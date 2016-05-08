<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AllBooks.aspx.cs" Inherits="aspprojecttt.AllBooks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    &nbsp;<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="BooksSource" AllowPaging="True" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" SelectedIndex="1">
        <Columns> 
            <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
            <asp:TemplateField>
                <HeaderTemplate>Title</HeaderTemplate>
                <ItemTemplate><%# XPath( "Title" ) %></ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ShowSelectButton="True" />
        </Columns>
    </asp:GridView>
    <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" DataSourceID="BookSource2" Height="50px" Width="125px">
        <Fields>
            <asp:TemplateField>
                <HeaderTemplate>Title</HeaderTemplate>
                <ItemTemplate><%# XPath( "Title" ) %></ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>Price</HeaderTemplate>
                <ItemTemplate><%# XPath( "Price" ) %></ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Category" HeaderText="Category" SortExpression="Category" />
            <asp:TemplateField>
                <HeaderTemplate>Title</HeaderTemplate>
                <ItemTemplate><%# XPath( "Authors" ) %></ItemTemplate>
            </asp:TemplateField>
        </Fields>
    </asp:DetailsView>
    <asp:XmlDataSource ID="BooksSource" runat="server" DataFile="~/Books.xml"></asp:XmlDataSource>
    <asp:XmlDataSource ID="BookSource2" runat="server" DataFile="~/Books.xml"></asp:XmlDataSource>
</asp:Content>
