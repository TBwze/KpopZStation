<%@ Page Title="" Language="C#" MasterPageFile="~/View/Nav.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="ProjectLabPSDT.View.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label2" runat="server" Text="Name"></asp:Label>
    <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
        <br />
    <asp:Label ID="Label3" runat="server" Text="Email"></asp:Label>
    <asp:TextBox ID="UserEmail" runat="server"></asp:TextBox>
        <br />
    <asp:Label ID="Label4" runat="server" Text="Gender"></asp:Label>
    <asp:DropDownList ID="UserGender" runat="server">
        <asp:ListItem>Select</asp:ListItem>
        <asp:ListItem>Male</asp:ListItem>
        <asp:ListItem>Female</asp:ListItem>
    </asp:DropDownList>
    <br />
    <asp:Label ID="Label1" runat="server" Text="Address"></asp:Label>
    <asp:TextBox ID="UserAddress" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label5" runat="server" Text="Password"></asp:Label>
    <asp:TextBox ID="UserPassword" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="ErrorMsg" runat="server" Text=""></asp:Label>
    <br />
    <asp:Button ID="Button1" runat="server" Text="Register" OnClick="Button1_Click"/>
</asp:Content>
