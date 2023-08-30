using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ProjectLabPSDT.Controller
{
    public class AlbumController
    {
        public static string cekName(string name)
        {
            if (name.Equals(""))
            {
                return "Name Must Not Be Empty";
            }
            else if (name.Length >= 50)
            {
                return "Name Must Be Smaller Than 50 Characters";
            }
            return "";
        }

        public static string cekDescription(string description)
        {
            if (description.Equals(""))
            {
                return "Description Must Not Be Empty";
            }
            else if (description.Length >= 255)
            {
                return "Description Must Be Smaller Than 255 Characters";
            }
            return "";
        }

        public static string cekPrice(int price)
        {
            if (price.Equals(""))
            {
                return "Price Must Not Be Empty";
            }
            else if (price < 100000 || price > 1000000)
            {
                return "Price Must Be Between 100000 and 1000000";
            }
            return "";

        }

        public static string cekStock(int stock)
        {
            if (stock.Equals(""))
            {
                return "Stock Must Not Be Empty";
            }
            else if (stock == 0)
            {
                return "Stock Must Be More Than 0";
            }
            return "";
        }

        public static string cekFile(HttpPostedFile file)
        {
            if (file.Equals(""))
            {
                return "Album Image Must Be Uploaded";
            }
            else
            {

                string FileExt = Path.GetExtension(file.FileName);
                FileExt = FileExt.ToLower();
                if (FileExt != ".png" && FileExt != ".jpg" && FileExt != ".jpeg" && FileExt != ".jfif")
                {
                    return "Image Must be .png/.jpg/.jpeg./jfif only";
                }
                if (file.ContentLength > 2048000)
                {
                    return "Image Must Not Be Larger Than 2 MB";
                }
            }
            return "";
        }

        public static string cekAlbum(string name, string description, int price, int stock, HttpPostedFile file)
        {
            string response = cekName(name);
            if (response.Equals(""))
            {
                response = cekDescription(description);
            }
            else if (response.Equals(""))
            {
                response = cekPrice(price);
            }
            else if (response.Equals(""))
            {
                response = cekStock(stock);
            }
            else if (response.Equals(""))
            {
                response = cekFile(file);
            }
            return response;
        }
    }
}