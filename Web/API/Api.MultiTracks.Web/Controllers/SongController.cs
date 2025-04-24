using Microsoft.AspNetCore.Mvc;
using Api.MultiTracks.Domain.Interfaces;

namespace Api.MultiTracks.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongController(IMultiTracksService multiTracksService, ILogger logger) : ControllerBase
    {
        private readonly IMultiTracksService _multiTracksService = multiTracksService;
        private readonly ILogger _logger = logger;

        [HttpGet("list")]
        public async Task<IActionResult> List(int pageNumber = 1, int pageSize = 10)
        {
            if (pageNumber <= 0 || pageSize <= 0)
            {
                return BadRequest("Page number and page size must be greater than 0.");
            }

            try
            {
                var songs = await _multiTracksService.ListAllSongs(pageNumber, pageSize);
                return Ok(songs);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while listing songs.");
                return StatusCode(500, "Server error.");
            }
        }
    }
}
