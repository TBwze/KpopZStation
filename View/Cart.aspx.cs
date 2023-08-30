using ProjectLabPSDT.Factory;
using ProjectLabPSDT.Handler;
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
    public partial class Cart : System.Web.UI.Page
    {
        public static string userRole;
        public static KpopZtationEntities data = SingletonDatabase.getInstance();
        public static int userID, transactionID, qty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["user_cookie"] != null)
                {
                    userRole = UserRepository.getRolebyID(Convert.ToInt32(Request.Cookies["user_cookie"].Value));
                    Session["user"] = Request.Cookies["user_cookie"].Value;
                    userID = Convert.ToInt32(Session["user"]);
                    if (userRole.Equals("Admin"))
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

        public static int getUserID()
        {
            return userID;
        }

        protected void checkout_Click(object sender, EventArgs e)
        {
            if (!CartHandler.cartIsEmpty(userID))
            {
                transactionID = TransactionHeaderHandler.generateTransactionID();
                DateTime transactionDate = DateTime.Now.Date;
                TransactionHeaderFactory.createTransactionHeader(transactionID, transactionDate, userID);
                data.SaveChanges();
            }
            foreach (var x in data.Carts)
            {
                if (x.CustomerID == userID)
                {
                    qty = Convert.ToInt32(x.Qty);
                    TransactionDetailFactory.createTransactionDetail(transactionID, x.AlbumID, qty);
                    CartHandler.deleteCart(x.CustomerID, x.AlbumID);
                }
            }
        }
    }
}