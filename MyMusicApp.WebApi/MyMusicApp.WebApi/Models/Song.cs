using System;

namespace MyMusicApp.WebApi.Models
{
    public class Song
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Author { get; set; }

        public string Cover { get; set; }

        public double Duration { get; set; }

        public MediaType Type { get; set; }

        public string MediaUrl { get; set; }

    }
}
