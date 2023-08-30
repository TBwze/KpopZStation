<%@ Page Title="" Language="C#" MasterPageFile="~/View/Nav.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="ProjectLabPSDT.View.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <% string visitorRole = getRole(); %>   
    <% if (visitorRole.Equals("Admin")) { %>
    <asp:Button ID="InsertArtist" runat="server" Text="Insert Artist" OnClick="InsertArtist_Click" />
    <br />
    <%} %>
    


    <table>
        <tr>
            <th>Image</th>
            <th>Name</th>
        </tr>
    <% foreach (var x in data.Artists) { %>
        <tr>
            <td>
                <a href="ArtistDetail.aspx?artistID=<%= x.ArtistID %>">
                    <img src="<%= x.ArtistImage %>" alt="Person Image" style="height: 100px; width: 100px" />
                </a>
            </td>
            <td>
                <a href="ArtistDetail.aspx?artistID=<%= x.ArtistID %>">
                    <%= x.ArtistName %>
                </a>
            </td>
            <%if (userRole.Equals("Admin")){ %>
            <td><a href="UpdateArtist.aspx?artistID=<%= x.ArtistID %>">Edit</a></td>
            <td><a href="DeleteArtist.aspx?artistID=<%= x.ArtistID %>">Delete</a></td>
            <%} %>
        </tr>
    <% } %>
</table>
</asp:Content>
