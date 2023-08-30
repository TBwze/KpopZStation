using ProjectLabPSDT.Controller;
using ProjectLabPSDT.Model;
using ProjectLabPSDT.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectLabPSDT.View
{
    public partial class UpdateArtist : System.Web.UI.Page
    {
        public static string userRole;
        public static KpopZtationEntities data = SingletonDatabase.getInstance();
        public Artist artist;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["user_cookie"] != null)
                {
                    userRole = UserRepository.getRolebyID(Convert.ToInt32(Request.Cookies["user_cookie"].Value));
                    Session["user"] = Request.Cookies["user_cookie"].Value;
                    if (!userRole.Equals("Admin"))
                    {
                        Response.Redirect("Home.aspx");
                    }
                }
                else
                {
                    Response.Redirect("Home.aspx");
                }
                int retrievedArtistID = Convert.ToInt32(Request["artistID"]);
                artist = ArtistRepository.findArtistByID(retrievedArtistID);
                NameBox.Text = artist.ArtistName;
                artistImage.ImageUrl = artist.ArtistImage;
            }
            else
            {
                Response.Redirect("Home.aspx");
            }
        }


        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            string newName = NameBox.Text;
            HttpPostedFile newFile = FileUpload1.PostedFile;
            ErrorMsg.Text = ArtistController.cekArtist(newName, newFile);
            if (ErrorMsg.Text.Equals(""))
            {
                string newFileName = DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(newFile.FileName);
                string newFilePath = Server.MapPath("~/Image/Artist/" + newFileName);

                newFile.SaveAs(newFilePath);

                string newImagePath = "/Image/Artist/" + newFileName;

                artist.ArtistName = newName;
                artist.ArtistImage = newImagePath;

                data.SaveChanges();
                Response.Redirect("Home.aspx");
            }

        }
    }
}