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
    public partial class InsertArtist : System.Web.UI.Page
    {
        public static string userRole;
        public static ArtistFactory ca = new ArtistFactory();
        public static KpopZtationEntities data = SingletonDatabase.getInstance();

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
            }
        }

        protected void InsertBtn_Click(object sender, EventArgs e)
        {
            string Name = NameBox.Text;
            HttpPostedFile file = FileUpload1.PostedFile;
            ErrorMsg.Text = ArtistController.cekArtist(Name, file);
            if (ErrorMsg.Text.Equals(""))
            {
                string fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(file.FileName);
                string filePath = Server.MapPath("~/Image/Artist/" + fileName);

                file.SaveAs(filePath);

                string imagePath = "/Image/Artist/" + fileName;

                int id = ArtistHandler.generateArtistID();
                Artist artist = ca.createArtist(id, Name, imagePath);
                data.Artists.Add(artist);
                data.SaveChanges();
            }
            Response.Redirect("Home.aspx");
        }
    }
}