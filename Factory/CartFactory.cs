using ProjectLabPSDT.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectLabPSDT.Factory
{
    public class CartFactory
    {
        public static Cart createCart(int userID, int albumID, int qty)
        {
            return new Cart
            {
                CustomerID = userID,
                AlbumID = albumID,
                Qty = qty
            };
        }
    }
}