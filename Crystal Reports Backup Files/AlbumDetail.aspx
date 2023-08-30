<%@ Page Title="" Language="C#" MasterPageFile="~/View/Nav.Master" AutoEventWireup="true" CodeBehind="AlbumDetail.aspx.cs" Inherits="ProjectLabPSDT.View.AlbumDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Image ID="Image1" runat="server" Height="100px" Width="100px" />
    <br />
    <asp:Label ID="albumName" runat="server" Text=""></asp:Label>
    <br />
    <asp:Label ID="albumDescription" runat="server" Text=""></asp:Label>
    <br />
    <asp:Label ID="albumPrice" runat="server" Text=""></asp:Label>
    <br />
    <asp:Label ID="albumStock" runat="server" Text=""></asp:Label>
    <br />
    <%string userRole = getUserRole(); %>
    <%if (userRole.Equals("User")) { %>
    <asp:Label ID="inputQty" runat="server" Text="Input Quantity"></asp:Label>
    <asp:TextBox ID="TextBox1" runat="server" ></asp:TextBox>
    <br />
    <asp:Label ID="ErrorMsg" runat="server" Text=""></asp:Label>
    <br />
    <asp:Button ID="addToCart" runat="server" Text="Add To Cart" OnClick="addToCart_Click" />
    <%} %>
</asp:Content>
