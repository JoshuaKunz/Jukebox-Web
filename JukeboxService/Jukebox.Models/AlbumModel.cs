using System.Collections.Generic;

namespace Jukebox.Models
{
    public class AlbumModel
    {
        public string AlbumTitle { get; set; }
        public string AlbumArtist { get; set; }
        public short AlbumYear { get; set; }
        public byte NumberOfTracks { get; set; }
        public List<SongModel> Songs { get; set; }
    }
}
