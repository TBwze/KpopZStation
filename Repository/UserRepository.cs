using ProjectLabPSDT.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectLabPSDT.Repository
{
    public class UserRepository
    {
        private static KpopZtationEntities data = SingletonDatabase.getInstance();

        public static Customer getCustomer(String Email, String Password)
        {
            return (from x in data.Customers where x.CustomerEmail.Equals(Email) && x.CustomerPassword.Equals(Password) select x).FirstOrDefault();
        }

        public static Customer getCustomerbyEmail(String Email)
        {
            return (from x in data.Customers where x.CustomerEmail.Equals(Email) select x).FirstOrDefault();
        }

        public static Customer getCustomerbyID(int id)
        {
            return (from x in data.Customers where x.CustomerID.Equals(id) select x).FirstOrDefault();
        }

        public static string getRolebyID(int id)
        {
            return (from x in data.Customers where x.CustomerID.Equals(id) select x.CustomerRole).FirstOrDefault();
        }
    }
}