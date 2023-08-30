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
    public partial class UpdateAlbum : System.Web.UI.Page
    {
        public static string userRole;
        public static int artistID;
        public static Album album;
        public static KpopZtationEntities data = SingletonDatabase.getInstance();
        public static int retrievedArtistID, retrievedAlbumID;

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

                retrievedArtistID = Convert.ToInt32(Request["artistID"]);
                retrievedAlbumID = Convert.ToInt32(Request["albumID"]);
                album = AlbumRepository.getAlbumByID(retrievedArtistID, retrievedAlbumID);

                AlbumImage.ImageUrl = album.AlbumImage;
                NameBox.Text = album.AlbumName;
                DescriptionBox.Text = album.AlbumDescription;
                PriceBox.Text = album.AlbumPrice.ToString();
                StockBox.Text = album.AlbumStock.ToString();
            }
            else
            {
                Response.Redirect("Home.aspx");
            }
        }


        protected void updateAlbum_Click(object sender, EventArgs e)
        {
            string newName = NameBox.Text;
            string newDescription = DescriptionBox.Text;
            int newPrice = Convert.ToInt32(PriceBox.Text);
            int newStock = Convert.ToInt32(StockBox.Text);
            HttpPostedFile newFile = FileUpload1.PostedFile;
            ErrorMsg.Text = AlbumController.cekAlbum(newName, newDescription, newPrice, newStock, newFile);
            if (ErrorMsg.Text.Equals(""))
            {
                string newFileName = DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(FileUpload1.FileName);
                string newFilePath = Server.MapPath("~/Image/Album/" + newFileName);

                FileUpload1.SaveAs(newFilePath);

                string newImagePath = "/Image/Album/" + newFileName;

                album.AlbumName = newName;
                album.AlbumDescription = newDescription;
                album.AlbumPrice = newPrice;
                album.AlbumStock = newStock;
                album.AlbumImage = newImagePath;

                data.SaveChanges();
            }
        }
    }
}