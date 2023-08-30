using ProjectLabPSDT.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectLabPSDT.Factory
{
    public class UserFactory
    {
        public Customer createCustomer(int id, string name, string email, string password, string gender, string address)
        {
            return new Customer
            {
                CustomerID = id,
                CustomerName = name,
                CustomerEmail = email,
                CustomerPassword = password,
                CustomerGender = gender,
                CustomerAddress = address,
                CustomerRole = "User"
            };
        }
    }
}