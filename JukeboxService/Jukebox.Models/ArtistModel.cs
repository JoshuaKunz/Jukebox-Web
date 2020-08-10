using System.Collections.Generic;

namespace Jukebox.Models
{
    public class ArtistModel
    {
        public string Artist { get; set; }
        public byte NumberOfAlbums { get; set; }
        public byte NumberOfSongs { get; set; }
        public List<AlbumModel> Albums { get; set; }
    }
}
