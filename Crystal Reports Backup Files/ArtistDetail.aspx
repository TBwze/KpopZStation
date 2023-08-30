<%@ Page Title="" Language="C#" MasterPageFile="~/View/Nav.Master" AutoEventWireup="true" CodeBehind="ArtistDetail.aspx.cs" Inherits="ProjectLabPSDT.View.ArtistDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Image ID="artistImage" runat="server" Height="100px" Width="100px" />
    <br />
    <asp:Label ID="nameLabel" runat="server" Text=""></asp:Label>
    <br />
    <br />
    <%int artistID = getArtistID(); %>
    <%string userRole = getUserRole();%>
    <table>
        <tr>
            <th>Image</th>
            <th>AlbumName</th>
            <th>AlbumPrice</th>
            <th>AlbumDescription</th>
        </tr>
    <% foreach(var x in data.Albums) { %>
        <%if(x.ArtistID == artistID){ %>
        <tr>
            <td>
                <a href="AlbumDetail.aspx?artistID=<%= x.ArtistID %>&albumID=<%= x.AlbumID%>">
                    <img src="<%= x.AlbumImage %>" alt="Person Image" style="height: 100px; width: 100px" />
                </a>
            </td>
            <td>
                <a href="AlbumDetail.aspx?artistID=<%= x.ArtistID %>&albumID=<%= x.AlbumID%>">
                    <%= x.AlbumName %>
                </a>
            </td>
            <td>
                <a href="AlbumDetail.aspx?artistID=<%= x.ArtistID %>&albumID=<%= x.AlbumID%>">
                    <%= x.AlbumPrice %>
                </a>
            </td>
            <td>
                <a href="AlbumDetail.aspx?artistID=<%= x.ArtistID %>&albumID=<%= x.AlbumID%>">
                    <%= x.AlbumDescription %>
                </a>
            </td>
            <%if (userRole.Equals("Admin")){ %>
            <td><a href="UpdateAlbum.aspx?artistID=<%= x.ArtistID %>&albumID=<%= x.AlbumID%>">Edit</a></td>
            <td><a href="DeleteAlbum.aspx?artistID=<%= x.ArtistID %>&albumID=<%= x.AlbumID%>">Delete</a></td>
            <%} %>
        </tr>
        <%} %>
    <% } %>
</table>

    <%if (userRole.Equals("Admin")){ %>
    <asp:Button ID="insertAlbum" runat="server" Text="Insert Album" OnClick="insertAlbum_Click" />
    <%} %>
</asp:Content>
