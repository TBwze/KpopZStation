using ProjectLabPSDT.Controller;
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
    public partial class Register : System.Web.UI.Page
    {
        public static KpopZtationEntities data = SingletonDatabase.getInstance();
        public static UserFactory createUser = new UserFactory();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string Name = UserName.Text;
            string Email = UserEmail.Text;
            string Gender = UserGender.SelectedValue;
            string Address = UserAddress.Text;
            string Password = UserPassword.Text;

            ErrorMsg.Text = UserController.cekRegister(Name, Email, Gender, Address, Password);
            if (ErrorMsg.Text.Equals(""))
            {
                int id = UserHandler.generateUserID();
                Customer newCustomer = createUser.createCustomer(id, Name, Email, Password, Gender, Address);
                data.Customers.Add(newCustomer);
                data.SaveChanges();
                Response.Redirect("Login.aspx");
            }
        }
    }
}