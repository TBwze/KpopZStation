using ProjectLabPSDT.Controller;
using ProjectLabPSDT.Handler;
using ProjectLabPSDT.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectLabPSDT.View
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String Email = UserEmail.Text;
            String Password = UserPassword.Text;
            bool isRemember = Remember.Checked;


            ErrorMsg.Text = UserController.loginCheck(Email, Password);
            if (ErrorMsg.Text.Equals(""))
            {
                Customer user = UserHandler.doLogin(Email, Password);
                if (isRemember)
                {
                    HttpCookie cookie = new HttpCookie("user_cookie");
                    cookie.Value = user.CustomerID.ToString();
                    cookie.Expires = DateTime.Now.AddDays(10);
                    Response.Cookies.Add(cookie);
                    Session["user"] = Request.Cookies["user_cookie"].Value;
                }
                Session["user"] = user.CustomerID.ToString();
                Response.Redirect("Home.aspx");
            }
        }

        protected void RegisterBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }
    }
}