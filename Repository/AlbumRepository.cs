using ProjectLabPSDT.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectLabPSDT.Repository
{
    public class AlbumRepository
    {
        public static KpopZtationEntities data = SingletonDatabase.getInstance();

        public static Album getAlbumByName(string name)
        {
            return (from x in data.Albums where x.AlbumName.Equals(name) select x).FirstOrDefault();
        }

        public static Album getAlbumByID(int artistID, int albumID)
        {
            Album album = (from x in data.Albums where x.ArtistID == artistID && x.AlbumID == albumID select x).FirstOrDefault();
            return album;

        }
    }
}