<%@ Page Title="" Language="C#" MasterPageFile="~/View/Nav.Master" AutoEventWireup="true" CodeBehind="UpdateArtist.aspx.cs" Inherits="ProjectLabPSDT.View.UpdateArtist" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="NameLbl" runat="server" Text="Name"></asp:Label>
    <asp:TextBox ID="NameBox" runat="server" Text=""></asp:TextBox>
    <br />
    <asp:Label ID="ImageLbl" runat="server" Text="Image"></asp:Label>
    <br />
    <asp:Image ID="artistImage" runat="server" width="200" height="200"/>
    <br />
    <asp:FileUpload ID="FileUpload1" runat="server" />
    <br />
    <asp:Label ID="ErrorMsg" runat="server" Text=""></asp:Label>
    <br />
    <asp:Button ID="UpdateBtn" runat="server" Text="Update Artist" Onclick="UpdateBtn_Click" />
</asp:Content>
