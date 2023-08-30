using ProjectLabPSDT.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectLabPSDT.Repository
{
    public class CartRepository
    {
        public static KpopZtationEntities data = SingletonDatabase.getInstance();

        public static Cart findCartByID(int userID, int albumID)
        {
            return (from x in data.Carts where x.CustomerID.Equals(userID) && x.AlbumID.Equals(albumID) select x).FirstOrDefault();
        }

        public static Cart findCartByUserID(int userID)
        {
            return (from x in data.Carts where x.CustomerID.Equals(userID) select x).FirstOrDefault();
        }

        public static void registerCart(Cart newCart)
        {
            data.Carts.Add(newCart);
            data.SaveChanges();
        }
    }
}