<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Fantasy.aspx.cs" Inherits="aspprojecttt.Fantasy" %>
     <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
            </asp:Content>
    <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:MultiView
        id="MultiView1"
        ActiveViewIndex="1"
        Runat="server">
        <asp:View ID="View1" runat="server" >
           
        </asp:View>        
        <asp:View ID="View2" runat="server">
            
        </asp:View>        
        <asp:View ID="View3" runat="server">
            
        </asp:View>        
    </asp:MultiView>

            </asp:Content>

