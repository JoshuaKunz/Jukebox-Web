using Jukebox.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JukeboxService.Service.Abstractions
{
    public interface IJukeboxService
    {
        Task<IEnumerable<SongModel>> GetAllSongs();
        Task<IEnumerable<AlbumModel>> GetAllAlbums();
        Task<IEnumerable<ArtistModel>> GetAllArtists();
    }
}
