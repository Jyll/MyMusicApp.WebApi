using System;
using System.Collections.Generic;
using MyMusicApp.WebApi.Models;
using System.Linq;

namespace MyMusicApp.WebApi.Services
{
    public class MusicLibraryService : IMusicLibrary, IDisposable
    {
        private readonly MusicAppContext _musicAppContext;

        public MusicLibraryService(MusicAppContext musicAppContext)
        {
            _musicAppContext = musicAppContext;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _musicAppContext.Dispose();
            }
        }

        public IList<Song> GetSongs(string GenreFilter = null)
        {
            return _musicAppContext.Song.Where(song => GenreFilter == null || string.CompareOrdinal(song.Genre, GenreFilter) == 0 ).ToList();
        }

        public IList<Song> GetSongsByArtist()
        {
            throw new NotImplementedException();
        }
    }
}
