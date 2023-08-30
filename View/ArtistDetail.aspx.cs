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
    public partial class ArtistDetail : System.Web.UI.Page
    {
        public static KpopZtationEntities data = SingletonDatabase.getInstance();
        public static string userRole;
        public static int artistID, retrievedArtistID;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                retrievedArtistID = Convert.ToInt32(Request["artistID"]);
                Artist currentArtist = ArtistRepository.findArtistByID(retrievedArtistID);
                nameLabel.Text = currentArtist.ArtistName;

                artistImage.ImageUrl = currentArtist.ArtistImage;
                artistID = currentArtist.ArtistID;
            }
            else
            {
                Response.Redirect("Home.aspx");
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

        public static int getArtistID()
        {
            return artistID;
        }

        protected void insertAlbum_Click(object sender, EventArgs e)
        {
            Response.Redirect("InsertAlbum.aspx?artistID=" + retrievedArtistID);
        }
    }
}