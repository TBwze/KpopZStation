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
    public partial class Home : System.Web.UI.Page
    {
        public static string userRole;
        public static KpopZtationEntities data = SingletonDatabase.getInstance();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (Request.Cookies["user_cookie"] != null)
            {
                int id = Convert.ToInt32(Request.Cookies["user_cookie"].Value);
                userRole = UserRepository.getRolebyID(id);
                Session["user"] = Request.Cookies["user_cookie"].Value;
            }
            else
            {
                userRole = "Guest";
            }
        }

        public static string getRole()
        {
            return userRole;
        }

        protected void InsertArtist_Click(object sender, EventArgs e)
        {
            Response.Redirect("InsertArtist.aspx");
        }
    }
}