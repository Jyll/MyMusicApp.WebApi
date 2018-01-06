namespace MyMusicApp.WebApi.Models.Test
{
    public partial class Song
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string CoverUrl { get; set; }
        public double Duration { get; set; }
        public string MediaUrl { get; set; }
        public int? AlbumId { get; set; }

        public Album Album { get; set; }
    }
}
