using MyMusicApp.WebApi.Models;
using System.Collections.Generic;

namespace MyMusicApp.WebApi.Services
{
    public interface IMusicLibrary
    {
        IList<Song> GetSongsByArtist();

        IList<Song> GetSongs(string GenreFilter = null);
    }
}