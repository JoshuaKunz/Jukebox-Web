using System;

namespace Jukebox.Models
{
    public class SongModel
    {
        public string Title { get; set; }
        public string Album { get; set; }
        public string Artist { get; set; }
        public string Path { get; set; }
        public byte TrackNumber { get; set; }
        public short Year { get; set; }
    }
}
