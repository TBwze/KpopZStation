using ProjectLabPSDT.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectLabPSDT.Repository
{
    public class ArtistRepository
    {
        public static KpopZtationEntities data = SingletonDatabase.getInstance();

        public static Artist findArtistByName(string Name)
        {
            return (from x in data.Artists where x.ArtistName.Equals(Name) select x).FirstOrDefault();
        }

        public static Artist findArtistByID(int id)
        {
            return (from x in data.Artists where x.ArtistID.Equals(id) select x).FirstOrDefault();
        }
    }
}