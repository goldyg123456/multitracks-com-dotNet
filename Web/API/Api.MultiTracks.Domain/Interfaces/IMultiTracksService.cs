using Api.MultiTracks.Domain.Models;

namespace Api.MultiTracks.Domain.Interfaces
{
    public interface IMultiTracksService
    {
        Task<Artist> AddArtist(Artist artist);
        Task<List<Song>> ListAllSongs(int pageNumber, int pageSize);
        Task<List<Artist>> SearchByArtist(string name);
    }
}