using Api.MultiTracks.Domain.Interfaces;
using Api.MultiTracks.Domain.Models;
using Api.MultiTracks.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace Api.MultiTracks.Web.UnitTests
{
    public class SongControllerTests
    {
        private readonly Mock<IMultiTracksService> _mockService;
        private readonly Mock<ILogger<SongController>> _mockLogger;
        private readonly SongController _controller;

        public SongControllerTests()
        {
            _mockService = new Mock<IMultiTracksService>();
            _mockLogger = new Mock<ILogger<SongController>>();
            _controller = new SongController(_mockService.Object, _mockLogger.Object);
        }

        [Fact]
        public async Task ListAllSongs_ReturnsPaginatedSongs()
        {
            // Arrange
            var songs = new List<Song>
            {
                new() { SongID = 1, Title = "Song 1", BPM = 120, TimeSignature = "4/4", ImageURL = "url" },
                new() { SongID = 2, Title = "Song 2", BPM = 100, TimeSignature = "3/4", ImageURL = "url" }
            };
            _mockService.Setup(repo => repo.ListAllSongs(1, 10))
                .ReturnsAsync(songs);

            // Act
            var result = await _controller.List(1, 10);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(songs, okResult.Value);
        }
    }
}
