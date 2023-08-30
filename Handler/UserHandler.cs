using ProjectLabPSDT.Model;
using ProjectLabPSDT.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectLabPSDT.Handler
{
    public class UserHandler
    {
        public static KpopZtationEntities data = SingletonDatabase.getInstance();

        public static Customer doLogin(String Email, String Password)
        {
            Customer customer = UserRepository.getCustomer(Email, Password);
            return customer;
        }

        public static int generateUserID()
        {
            if (!data.Customers.Any())
            {
                return 1;
            }
            else
            {
                return data.Customers.Max(a => a.CustomerID) + 1;
            }
        }
    }
}