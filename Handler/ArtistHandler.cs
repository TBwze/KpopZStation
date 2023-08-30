using ProjectLabPSDT.Model;
using ProjectLabPSDT.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectLabPSDT.Handler
{
    public class ArtistHandler
    {
        public static KpopZtationEntities data = SingletonDatabase.getInstance();

        public static int generateArtistID()
        {
            if (!data.Artists.Any())
            {
                return 1;
            }
            else
            {
                return data.Artists.Max(a => a.ArtistID) + 1;
            }
        }

        public static bool nameIsUnique(string name)
        {
            Artist artist = ArtistRepository.findArtistByName(name);
            if (artist == null)
            {
                return true;
            }
            return false;
        }

        public static void deleteArtist(int artistID){
            Artist artist=ArtistRepository.findArtistByID(artistID);
            data.Artists.Remove(artist);
            data.SaveChanges();
        }
    }
}