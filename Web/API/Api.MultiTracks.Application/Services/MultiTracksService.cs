using Api.MultiTracks.Domain.Interfaces;
using Api.MultiTracks.Domain.Models;

namespace Api.MultiTracks.Application.Services
{
    public class MultiTracksService(IMultiTracksRepository repository) : IMultiTracksService
    {
        private readonly IMultiTracksRepository _repository = repository;

        // Search for artists by title
        public async Task<List<Artist>> SearchByArtist(string name)
        {
            return await _repository.SearchByArtist(name);
        }

        // Add a new artist
        public async Task<Artist> AddArtist(Artist artist)
        {
            return await _repository.AddArtist(artist);
        }

        // List all songs with pagination
        public async Task<List<Song>> ListAllSongs(int pageNumber, int pageSize)
        {
            return await _repository.ListAllSongs(pageNumber, pageSize);
        }
    }
}
