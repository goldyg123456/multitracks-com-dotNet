using Microsoft.EntityFrameworkCore;
using Api.MultiTracks.Domain.Models;

namespace Api.MultiTracks.Infrastructure.Data
{
    public class MultiTracksDbContext(DbContextOptions<MultiTracksDbContext> options) : DbContext(options)
    {

        // DbSets for each table in the database
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Song> Songs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure the Artist entity
            modelBuilder.Entity<Artist>(entity =>
            {
                entity.HasKey(a => a.ArtistID);
                entity.Property(a => a.Title).IsRequired().HasMaxLength(255);
                entity.Property(a => a.Biography).HasMaxLength(2000);
                entity.Property(a => a.ImageURL).HasMaxLength(500);
                entity.Property(a => a.HeroURL).HasMaxLength(500);
            });

            // Configure the Song entity
            modelBuilder.Entity<Song>(entity =>
            {
                entity.HasKey(s => s.SongID);
                entity.Property(s => s.Title).IsRequired().HasMaxLength(255);
                entity.Property(s => s.ImageURL).HasMaxLength(500);
            });
        }
    }
}
