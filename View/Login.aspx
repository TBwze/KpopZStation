<%@ Page Title="" Language="C#" MasterPageFile="~/View/Nav.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ProjectLabPSDT.View.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Email" runat="server" Text="Email"></asp:Label>
    <asp:TextBox ID="UserEmail" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Password" runat="server" Text="Password"></asp:Label>
    <asp:TextBox ID="UserPassword" runat="server"></asp:TextBox>
    <br />
    <asp:CheckBox ID="Remember" runat="server" Text="Remember Me"/>
    <br />
    <asp:Label ID="ErrorMsg" runat="server" Text=""></asp:Label>
    <br />
    <asp:Button ID="Button1" runat="server" Text="Login" OnClick="Button1_Click"/>
    <asp:Button ID="RegisterBtn" runat="server" Text="Register" OnClick="RegisterBtn_Click"/>
</asp:Content>
