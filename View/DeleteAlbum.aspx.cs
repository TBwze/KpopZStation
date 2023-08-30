using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectLabPSDT.Handler;
using ProjectLabPSDT.Model;
using ProjectLabPSDT.Repository;

namespace ProjectLabPSDT.View
{
    public partial class DeleteAlbum : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int artistID = Convert.ToInt32(Request["artistID"]);
            int albumID = Convert.ToInt32(Request["albumID"]);
            AlbumHandler.deleteAlbum(artistID, albumID);
            Response.Redirect("Home.aspx");
        }

    }
}