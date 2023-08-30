using ProjectLabPSDT.Handler;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ProjectLabPSDT.Controller
{
    public class ArtistController
    {
        public static string cekName(string name)
        {
            if (name.Equals(""))
            {
                return "Name Must Not Be Empty";
            }
            else if (!ArtistHandler.nameIsUnique(name))//IF NOT UNIQUE
            {
                return "Artist's Name Must Be Unique";
            }
            return "";
        }

        public static string cekFile(HttpPostedFile file)
        {
            if (file.Equals(""))
            {
                return "Artist Image Must Be Uploaded";
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

        public static string cekArtist(string Name, HttpPostedFile file)
        {
            string response = cekName(Name);
            if (response.Equals(""))
            {
                response = cekFile(file);
            }
            return response;
        }
    }
}