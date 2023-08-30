using ProjectLabPSDT.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectLabPSDT.Factory
{
    public class ArtistFactory
    {
        public Artist createArtist(int id, string name, string image)
        {
            return new Artist
            {
                ArtistID = id,
                ArtistName = name,
                ArtistImage = image
            };
        }
    }
}