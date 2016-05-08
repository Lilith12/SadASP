<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Book.aspx.cs" Inherits="aspprojecttt.Book" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="display" runat="server">
        
    </div>
    <asp:Button ID="addToCartButton" runat="server" Text="Dodaj do koszyka" OnClick="addToCart"/>
</asp:Content>
