using System;
using System.Collections.Generic;
using System.Linq;

namespace MyMusicApp.WebApi.Models
{
    public class Album
    {
        public Guid Id { get; set; }

        public string Author { get; set; }

        public double Duration => TrackList?.Sum(song => song.Duration) ?? 0;

        public DateTime? ReleaseDate { get; set; }

        public IList<Song> TrackList { get; set; }

        public string MediaUrl { get; set; }

        public string CoverUrl { get; set; }
    }
}
