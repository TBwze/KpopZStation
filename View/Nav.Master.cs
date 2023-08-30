using ProjectLabPSDT.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectLabPSDT.View
{
    public partial class Nav : System.Web.UI.MasterPage
    {
        public static string userRole;
        public static int id;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["user_cookie"] != null)
            {
                id = Convert.ToInt32(Request.Cookies["user_cookie"].Value);
                userRole = UserRepository.getRolebyID(id);
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

        protected void Home_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void Register_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }

        protected void Login_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["user_cookie"];
            cookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(cookie);
            Response.Redirect("Home.aspx");
        }

        protected void updateProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("UpdateProfile.aspx?userID=" + id);
        }

        protected void transaction_Click(object sender, EventArgs e)
        {
            if (userRole.Equals("Admin"))
            {
                Response.Redirect("TransactionReport.aspx");
            }
            else if (userRole.Equals("User"))
            {
                Response.Redirect("TransactionHistory.aspx");
            }
        }

        protected void cart_Click(object sender, EventArgs e)
        {
            Response.Redirect("Cart.aspx");
        }
    }
}