using ProjectLabPSDT.Factory;
using ProjectLabPSDT.Model;
using ProjectLabPSDT.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectLabPSDT.Handler
{
    public class CartHandler
    {
        public static KpopZtationEntities data = SingletonDatabase.getInstance();

        public static void cartIsAvailable(int userID, int albumID, int qty)
        {
            if (CartRepository.findCartByID(userID, albumID) == null)
            {
                Cart newCart = CartFactory.createCart(userID, albumID, qty);
                CartRepository.registerCart(newCart);
            }
            else
            {
                Cart cart = CartRepository.findCartByID(userID, albumID);
                cart.Qty = cart.Qty + qty;
                data.SaveChanges();
            }
        }

        public static bool cartIsEmpty(int userID)
        {
            if (CartRepository.findCartByUserID(userID) == null)
            {
                return true;
            }
            return false;
        }

        public static void deleteCart(int userID, int albumID)
        {
            Cart cartToDelete = CartRepository.findCartByID(userID, albumID);
            data.Carts.Remove(cartToDelete);
            data.SaveChanges();
        }
    }
}