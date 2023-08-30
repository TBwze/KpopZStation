<%@ Page Title="" Language="C#" MasterPageFile="~/View/Nav.Master" AutoEventWireup="true" CodeBehind="InsertArtist.aspx.cs" Inherits="ProjectLabPSDT.View.InsertArtist" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:Label ID="NameLbl" runat="server" Text="Name"></asp:Label>
    <asp:TextBox ID="NameBox" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="ImageLbl" runat="server" Text="Image"></asp:Label>
    <br />
    <asp:FileUpload ID="FileUpload1" runat="server" />
    <br />
    <asp:Label ID="ErrorMsg" runat="server" Text=""></asp:Label>
    <br />
    <asp:Button ID="InsertBtn" runat="server" Text="Insert Artist" OnClick="InsertBtn_Click" />
</asp:Content>
