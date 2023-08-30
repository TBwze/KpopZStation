<%@ Page Title="" Language="C#" MasterPageFile="~/View/Nav.Master" AutoEventWireup="true" CodeBehind="UpdateAlbum.aspx.cs" Inherits="ProjectLabPSDT.View.UpdateAlbum" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Image ID="AlbumImage" runat="server" width="200" height="200"/>
    <br />
    <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label>
    <asp:TextBox ID="NameBox" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label2" runat="server" Text="Description"></asp:Label>
    <asp:TextBox ID="DescriptionBox" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label3" runat="server" Text="Price"></asp:Label>
    <asp:TextBox ID="PriceBox" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label4" runat="server" Text="Stock"></asp:Label>
    <asp:TextBox ID="StockBox" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label5" runat="server" Text="Image"></asp:Label>
    <br />
    <asp:FileUpload ID="FileUpload1" runat="server" />
    <br />
    <asp:Label ID="ErrorMsg" runat="server" Text=""></asp:Label>
    <br />
    <asp:Button ID="updateAlbum" runat="server" Text="Update Album" OnClick="updateAlbum_Click" />
</asp:Content>
