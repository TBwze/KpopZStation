using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectLabPSDT.Controller
{
    public class QuantityController
    {
        public static string cekQuantity(int albumQty, int qty)
        {
            if (qty.Equals(""))
            {
                return "Quantity Cannot Be Empty";
            }
            else if (albumQty < qty)
            {
                return "Quantity Cannot Be More Than Album Stock";
            }
            return "";
        }
    }
}