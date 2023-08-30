using ProjectLabPSDT.Handler;
using ProjectLabPSDT.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectLabPSDT.Controller
{
    public class UserController
    {
        //LOGIN USER CONTROLLER
        public static String cekLoginEmail(String Email)
        {
            if (Email.Equals(""))
            {
                return "Email Must Not Be Empty";
            }
            return "";

        }

        public static String cekLoginPassword(String Password)
        {
            if (Password.Equals(""))
            {
                return "Password Must Not Be Empty";
            }
            return "";
        }

        public static String loginCheck(String Email, String Password)
        {
            String response = cekLoginEmail(Email);
            if (response.Equals(""))
            {
                response = cekLoginPassword(Password);
            }
            if (response.Equals(""))
            {
                if (UserHandler.doLogin(Email, Password) == null)
                {
                    response = "Wrong Username or Password";
                }
            }

            return response;

        }


        //REGISTER USER CONTROLLER
        public static String cekRegisterName(String Name)
        {
            if (Name.Equals(""))
            {
                return "Name Must Not Be Empty";
            }
            else if (Name.Length < 5 || Name.Length > 50)
            {
                return "Name Must Be Between 5 - 50 Characters";
            }
            return "";
        }

        public static String cekRegisterEmail(String Email)
        {
            if (Email.Equals(""))
            {
                return "Email Must Not be Empty";
            }
            if (UserRepository.getCustomerbyEmail(Email) != null)
            {
                return "Email Must Be Unique";
            }
            return "";
        }

        public static string cekRegisterGender(string Gender)
        {
            if (Gender.Equals("Select"))
            {
                return "Gender Must Be Selected";
            }
            if (Gender.Length > 6)
            {
                return "Gender Must Not Be Longer Than 6 Characters";
            }
            return "";
        }

        public static String cekRegisterAddress(String Address)
        {
            if (Address.Equals(""))
            {
                return "Address Must Not Be Empty";
            }
            if (!Address.EndsWith("Street"))
            {
                return "Address Must Ends In 'Street'";
            }
            return "";
        }

        public static String cekRegisterPassword(String Password)
        {
            if (Password.Equals(""))
            {
                return "Password Must Not Be Empty";
            }
            if (!Password.All(char.IsLetterOrDigit))
            {
                return "Password Must Be Alphanumeric";
            }
            return "";
        }


        public static String cekRegister(String Name, String Email, String Gender, String Address, String Password)
        {
            String response = cekRegisterName(Name);
            if (response.Equals(""))
            {
                response = cekRegisterEmail(Email);
            }
            if (response.Equals(""))
            {
                response = cekRegisterGender(Gender);
            }
            if (response.Equals(""))
            {
                response = cekRegisterAddress(Address);
            }
            if (response.Equals(""))
            {
                response = cekRegisterPassword(Password);
            }
            return response;
        }
    }
}