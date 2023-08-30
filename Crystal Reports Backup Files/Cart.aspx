<%@ Page Title="" Language="C#" MasterPageFile="~/View/Nav.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="ProjectLabPSDT.View.Cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%int userID = getUserID(); %>
    <table>
        <tr>
            <th>Image</th>
            <th>AlbumName</th>
            <th>Quantity</th>
            <th>AlbumPrice</th>
        </tr>
    <% foreach(var x in data.Carts) { %>
        <%if(x.CustomerID == userID){ %>
        <tr>
            <td>
                <img src="<%= x.Album.AlbumImage %>" alt="Person Image" style="height: 100px; width: 100px" />
            </td>
            <td>
                <%= x.Album.AlbumName %>
            </td>
            <td>
               <%= x.Qty %>
            </td>
            <td>
               <%= x.Album.AlbumPrice %>
            </td>
            <td><a href="RemoveAlbum.aspx?userID=<%= x.CustomerID %>&albumID=<%= x.AlbumID%>">Remove</a></td>
        </tr>
        <%} %>
    <% } %>
</table>
    <asp:Button ID="checkout" runat="server" Text="Checkout" OnClick="checkout_Click"/>
</asp:Content>
