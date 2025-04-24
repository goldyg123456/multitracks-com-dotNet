using Microsoft.AspNetCore.Mvc;
using Api.MultiTracks.Domain.Models;
using Api.MultiTracks.Domain.Interfaces;

namespace Api.MultiTracks.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArtistController(IMultiTracksService multiTracksService, ILogger logger) : ControllerBase
    {
        private readonly IMultiTracksService _multiTracksService = multiTracksService;
        private readonly ILogger _logger = logger;

        [HttpGet("search")]
        public async Task<IActionResult> Search(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return BadRequest("The name is required.");
            }

            try
            {
                var artists = await _multiTracksService.SearchByArtist(name);
                return Ok(artists);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while listing songs.");
                return StatusCode(500, "Server error.");
            }
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] Artist artist)
        {
            try
            {
                var createdArtist = await _multiTracksService.AddArtist(artist);
                return CreatedAtAction(nameof(Search), new { title = createdArtist.Title }, createdArtist);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while listing songs.");
                return StatusCode(500, "Server error.");
            }
        }
    }
}
