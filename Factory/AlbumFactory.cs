using ProjectLabPSDT.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectLabPSDT.Factory
{
    public class AlbumFactory
    {
        public Album createAlbum(int albumID, int artistID, string albumName, string albumImage, int albumPrice, int albumStock, string albumDescription)
        {
            return new Album
            {
                AlbumID = albumID,
                ArtistID = artistID,
                AlbumName = albumName,
                AlbumImage = albumImage,
                AlbumPrice = albumPrice,
                AlbumStock = albumStock,
                AlbumDescription = albumDescription
            };
        }
    }
}