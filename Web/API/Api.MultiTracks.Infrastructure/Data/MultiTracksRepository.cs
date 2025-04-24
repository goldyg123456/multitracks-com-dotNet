using Microsoft.EntityFrameworkCore;
using Api.MultiTracks.Domain.Models;
using Api.MultiTracks.Domain.Interfaces;

namespace Api.MultiTracks.Infrastructure.Data
{
    public class MultiTracksRepository(MultiTracksDbContext context) : IMultiTracksRepository
    {
        private readonly MultiTracksDbContext _context = context;

        // Search for artists by title
        public async Task<List<Artist>> SearchByArtist(string name)
        {
            return await _context.Artists
                .Where(a => EF.Functions.Like(a.Title, $"%{name}%"))
                .ToListAsync();
        }

        // Add a new artist
        public async Task<Artist> AddArtist(Artist artist)
        {
            _context.Artists.Add(artist);
            await _context.SaveChangesAsync();
            return artist;
        }

        // List all songs with pagination
        public async Task<List<Song>> ListAllSongs(int pageNumber, int pageSize)
        {
            return await _context.Songs
                .OrderBy(s => s.Title)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
    }
}
