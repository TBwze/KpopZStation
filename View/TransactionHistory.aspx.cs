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
    public partial class TransactionHistory : System.Web.UI.Page
    {
        public static string userRole;
        public static KpopZtationEntities data = SingletonDatabase.getInstance();
        public static int userID, transactionID, qty;
        public static Customer user;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["user_cookie"] != null)
                {
                    userRole = UserRepository.getRolebyID(Convert.ToInt32(Request.Cookies["user_cookie"].Value));
                    Session["user"] = Request.Cookies["user_cookie"].Value;
                    userID = Convert.ToInt32(Session["user"]);
                    user = UserRepository.getCustomerbyID(userID);
                    userName.Text = user.CustomerName;
                }
                else
                {
                    Response.Redirect("Home.aspx");
                }
            }
        }

        public static int getUserID()
        {
            return userID;
        }
    }
}