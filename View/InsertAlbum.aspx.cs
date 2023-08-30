using ProjectLabPSDT.Controller;
using ProjectLabPSDT.Factory;
using ProjectLabPSDT.Handler;
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
    public partial class InsertAlbum : System.Web.UI.Page
    {
        public static string userRole;
        public static AlbumFactory ca = new AlbumFactory();
        public static KpopZtationEntities data = SingletonDatabase.getInstance();
        public static int retrievedArtistID;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                retrievedArtistID = Convert.ToInt32(Request["artistID"]);
                if (Request.Cookies["user_cookie"] != null)
                {
                    userRole = UserRepository.getRolebyID(Convert.ToInt32(Request.Cookies["user_cookie"].Value));
                    Session["user"] = Request.Cookies["user_cookie"].Value;
                    if (userRole.Equals("Guest") || userRole.Equals("User"))
                    {
                        Response.Redirect("Home.aspx");
                    }
                }
                else
                {
                    Response.Redirect("Home.aspx");
                }
            }
        }

        protected void InsertAlbum_Click(object sender, EventArgs e)
        {
            string name = NameBox.Text;
            string description = DescriptionBox.Text;
            int price = Convert.ToInt32(PriceBox.Text);
            int stock = Convert.ToInt32(StockBox.Text);
            HttpPostedFile file = FileUpload1.PostedFile;
            ErrorMsg.Text = AlbumController.cekAlbum(name, description, price, stock, file);
            if (ErrorMsg.Text.Equals(""))
            {
                string fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(FileUpload1.FileName);
                string filePath = Server.MapPath("~/Image/Album/" + fileName);

                FileUpload1.SaveAs(filePath);

                string imagePath = "/Image/Album/" + fileName;

                int artistid = retrievedArtistID;
                int id = AlbumHandler.generateAlbumID();

                Album newAlbum = ca.createAlbum(id, artistid, name, imagePath, price, stock, description);

                data.Albums.Add(newAlbum);
                data.SaveChanges();
            }
        }
    }
}