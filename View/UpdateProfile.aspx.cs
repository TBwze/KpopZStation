using ProjectLabPSDT.Controller;
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
    public partial class UpdateProfile : System.Web.UI.Page
    {
        public static string userRole;
        public static Customer user;
        public static KpopZtationEntities data = SingletonDatabase.getInstance();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["user_cookie"] != null)
                {
                    userRole = UserRepository.getRolebyID(Convert.ToInt32(Request.Cookies["user_cookie"].Value));
                    Session["user"] = Request.Cookies["user_cookie"].Value;
                }
                else
                {
                    Response.Redirect("Home.aspx");
                }
            }
            else
            {
                Response.Redirect("Home.aspx");
            }
            int retrievedUserID = Convert.ToInt32(Request["userID"]);
            user = UserRepository.getCustomerbyID(retrievedUserID);
            UserName.Text = user.CustomerName;
            UserEmail.Text = user.CustomerEmail;
            UserGender.SelectedValue = user.CustomerGender;
            UserAddress.Text = user.CustomerAddress;
            UserPassword.Text = user.CustomerPassword;
        }

        protected void updateUser_Click(object sender, EventArgs e)
        {
            String newName = UserName.Text;
            String newEmail = UserEmail.Text;
            String newGender = UserGender.SelectedValue;
            String newAddress = UserAddress.Text;
            String newPassword = UserPassword.Text;

            ErrorMsg.Text = UserController.cekRegister(newName, newEmail, newGender, newAddress, newPassword);
            if (ErrorMsg.Text.Equals(""))
            {
                user.CustomerName = newName;
                user.CustomerEmail = newEmail;
                user.CustomerGender = newGender;
                user.CustomerAddress = newAddress;
                user.CustomerPassword = newPassword;

                data.SaveChanges();
                Response.Redirect("Home.aspx");
            }
        }
    }
}