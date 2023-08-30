using ProjectLabPSDT.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectLabPSDT.View
{
    public partial class DeleteArtist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int artistID = Convert.ToInt32(Request["artistID"]);
            ArtistHandler.deleteArtist(artistID);
            Response.Redirect("Home.aspx");
        }
    }
}