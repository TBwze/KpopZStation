using ProjectLabPSDT.Controller;
using ProjectLabPSDT.Handler;
using ProjectLabPSDT.Model;
using ProjectLabPSDT.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectLabPSDT.View
{
    public partial class AlbumDetail : System.Web.UI.Page
    {
        public static string userRole;
        public static KpopZtationEntities data = SingletonDatabase.getInstance();
        public static int retrievedArtistID, retrievedAlbumID;
        public static Album album;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                retrievedArtistID = Convert.ToInt32(Request["artistID"]);
                retrievedAlbumID = Convert.ToInt32(Request["albumID"]);
                album = AlbumRepository.getAlbumByID(retrievedArtistID, retrievedAlbumID);

                Image1.ImageUrl = album.AlbumImage;
                albumName.Text = album.AlbumName;
                albumDescription.Text = album.AlbumDescription;
                albumPrice.Text = album.AlbumPrice.ToString();
                albumStock.Text = album.AlbumStock.ToString();
            }
        }

        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (Request.Cookies["user_cookie"] != null)
            {
                userRole = UserRepository.getRolebyID(Convert.ToInt32(Request.Cookies["user_cookie"].Value));
                Session["user"] = Request.Cookies["user_cookie"].Value;
            }
            else
            {
                userRole = "Guest";
            }
        }

        public static string getUserRole()
        {
            return userRole;
        }

        protected void addToCart_Click(object sender, EventArgs e)
        {
            int qty = Convert.ToInt32(inputQty.Text);
            int stock = Convert.ToInt32(album.AlbumStock);
            ErrorMsg.Text = QuantityController.cekQuantity(stock, qty);
            int userID = Convert.ToInt32(Session["user"]);
            if (ErrorMsg.Text.Equals(""))
            {
                CartHandler.cartIsAvailable(userID, retrievedAlbumID, qty);
            }
            Response.Redirect("Home.aspx");
        }
    }
}