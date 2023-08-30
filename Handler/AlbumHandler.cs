using ProjectLabPSDT.Model;
using ProjectLabPSDT.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectLabPSDT.Handler
{
    public class AlbumHandler
    {
        public static KpopZtationEntities data = SingletonDatabase.getInstance();

        public static int generateAlbumID()
        {
            if (!data.Albums.Any())
            {
                return 1;
            }
            else
            {
                return data.Albums.Max(a => a.AlbumID) + 1;
            }
        }

        public static void deleteAlbum(int artistID, int albumID)
        {
            Album album = AlbumRepository.getAlbumByID(artistID, albumID);
            data.Albums.Remove(album);
            data.SaveChanges();
        }
    }
}