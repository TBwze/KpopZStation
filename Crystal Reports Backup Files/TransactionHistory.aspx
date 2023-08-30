<%@ Page Title="" Language="C#" MasterPageFile="~/View/Nav.Master" AutoEventWireup="true" CodeBehind="TransactionHistory.aspx.cs" Inherits="ProjectLabPSDT.View.TransactionHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Customer's Name : "></asp:Label> <asp:Label ID="userName" runat="server" Text=""></asp:Label>
    <br />

    <table>
        <tr>
            <th>Transaction ID</th>
            <th>Transaction Date</th>
            <th>Album's Picture</th>
            <th>Album's Name</th>
            <th>Album's Quantity</th>
            <th>Album's Price</th>
        </tr>
    <% foreach (var x in data.TransactionHeaders) { %>
        <%if (x.CustomerID == userID){ %>
        <tr>
            <td>
                <%= x.TransactionID %>
            </td>
            <td>
                <%=x.TransactionDate %>
            </td>
            <%foreach (var y in x.TransactionDetails){ %>
                <%if (y.TransactionID == x.TransactionID){ %>
                <td>
                <img src="<%= y.Album.AlbumImage %>" alt="Person Image" style="height: 100px; width: 100px" />
                </td>
                <td>
                <%= y.Album.AlbumName %>
                </td>
                <td>
                <%= y.Qty %>
                </td>
                <td>
                <%= y.Album.AlbumPrice %>
                </td>
                <%} %>
            <%} %>
        </tr>
        <%} %>
    <% } %>
</table>
</asp:Content>
