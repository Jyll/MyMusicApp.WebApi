using Microsoft.EntityFrameworkCore;

namespace MyMusicApp.WebApi.Models
{
    public partial class MusicAppContext : DbContext
    {
        public virtual DbSet<Album> Album { get; set; }
        public virtual DbSet<Song> Song { get; set; }

        public MusicAppContext() : base() { }

        public MusicAppContext(DbContextOptions<MusicAppContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Album>(entity =>
            {
                entity.Property(e => e.AlbumUrl).HasMaxLength(1);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Genre)
                    .HasMaxLength(50);

                entity.Property(e => e.ReleaseDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Song>(entity =>
            {
                entity.Property(e => e.Author)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.CoverUrl).HasMaxLength(256);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Genre)
                    .HasMaxLength(50);

                entity.HasOne(d => d.Album)
                    .WithMany(p => p.Songs)
                    .HasForeignKey(d => d.AlbumId)
                    .HasConstraintName("FK_Album");
            });
        }
    }
}
