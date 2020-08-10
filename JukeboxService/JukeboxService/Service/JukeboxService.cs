using Jukebox.Models;
using JukeboxService.Service.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;


namespace JukeboxService.Service
{
    public class JukeboxService : IJukeboxService
    {
        public async Task<IEnumerable<AlbumModel>> GetAllAlbums()
        {
            var albumGroups = (await GetAllSongs()).GroupBy(x => x.Album);

            var albums = new List<AlbumModel>();

            foreach(var album in albumGroups)
            {
                var temp = album.FirstOrDefault();

                var newAlbum = new AlbumModel
                {
                    AlbumArtist = temp.Artist,
                    AlbumTitle = temp.Album,
                    AlbumYear = temp.Year,
                    Songs = new List<SongModel>()
                };

                foreach (var song in album)
                {
                    newAlbum.Songs.Add(song);
                    newAlbum.NumberOfTracks += 1;
                }

                newAlbum.Songs = newAlbum.Songs.OrderBy(x => x.TrackNumber).ToList();

                albums.Add(newAlbum);
            }

            albums = albums.OrderBy(x => x.AlbumArtist).ThenBy(x => x.AlbumTitle).ToList();

            return albums;
        }

        public async Task<IEnumerable<ArtistModel>> GetAllArtists()
        {
            var artistGroups = (await GetAllAlbums()).GroupBy(x => x.AlbumArtist);

            var artists = new List<ArtistModel>();

            foreach (var artist in artistGroups)
            {
                var temp = artist.FirstOrDefault();

                var newArtist = new ArtistModel
                {
                    Artist = temp.AlbumArtist,
                    Albums = new List<AlbumModel>()
                };

                foreach (var album in artist)
                {
                    newArtist.Albums.Add(album);
                    newArtist.NumberOfAlbums += 1;

                    foreach(var song in album.Songs)
                    {
                        newArtist.NumberOfSongs += 1;
                    }
                }
                artists.Add(newArtist);
            }

            return artists.OrderBy(x => x.Artist);
        }

        public Task<IEnumerable<SongModel>> GetAllSongs()
        {
            return Task.Run(() =>
            {
                var musicFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);

                var songs = new List<SongModel>();

                foreach (var folder in Directory.GetDirectories(musicFolder))
                {
                    var files = Directory.EnumerateFiles(folder, "*.mp3", SearchOption.AllDirectories);
                    songs.AddRange(ConvertFilePathsToSongModel(files));
                }

                return songs.AsEnumerable();
            });
        }

        private IEnumerable<SongModel> ConvertFilePathsToSongModel(IEnumerable<string> paths)
        {
            var songModels = new List<SongModel>();

            foreach (var path in paths)
            {
                var file = TagLib.File.Create(path).Tag;

                songModels.Add(new SongModel
                {
                    Artist = file.FirstAlbumArtist,
                    Title = file.Title,
                    TrackNumber = (byte)file.Track,
                    Path = path,
                    Year = (short)file.Year,
                    Album = file.Album
                });
            }

            return songModels.AsEnumerable();
        }
    }
}
