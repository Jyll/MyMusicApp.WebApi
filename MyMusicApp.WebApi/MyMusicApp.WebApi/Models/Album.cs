using System;
using System.Collections.Generic;

namespace MyMusicApp.WebApi.Models.Test
{
    public partial class Album
    {
        public Album()
        {
            Songs = new HashSet<Song>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string CoverUrl { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string AlbumUrl { get; set; }

        public ICollection<Song> Songs { get; set; }
    }
}
