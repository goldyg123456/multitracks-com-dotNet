using Api.MultiTracks.Domain.Interfaces;
using Api.MultiTracks.Domain.Models;
using Api.MultiTracks.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace Api.MultiTracks.Web.UnitTests
{
    public class ArtistControllerTests
    {
        private readonly Mock<IMultiTracksService> _mockService;
        private readonly Mock<ILogger<ArtistController>> _mockLogger;
        private readonly ArtistController _controller;

        public ArtistControllerTests()
        {
            _mockService = new Mock<IMultiTracksService>();
            _mockLogger = new Mock<ILogger<ArtistController>>();
            _controller = new ArtistController(_mockService.Object, _mockLogger.Object);
        }

        [Fact]
        public async Task Search_ReturnsBadRequest_WhenNameIsNull()
        {
            // Act
            var result = await _controller.Search(string.Empty);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("The name is required.", badRequestResult.Value);
        }

        [Fact]
        public async Task Search_ReturnsArtists_WhenNameIsValid()
        {
            // Arrange
            var artists = new List<Artist>
            {
                new() { ArtistID = 1, Title = "Artist 1", Biography = "Bio", ImageURL = "url", HeroURL = "url" }
            };
            _mockService.Setup(repo => repo.SearchByArtist("Artist"))
                .ReturnsAsync(artists);

            // Act
            var result = await _controller.Search("Artist");

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(artists, okResult.Value);
        }

        [Fact]
        public async Task Add_ReturnsCreatedResult_WhenArtistIsValid()
        {
            // Arrange
            var artist = new Artist { ArtistID = 1, Title = "Artist 1", Biography = "Bio", ImageURL = "url", HeroURL = "url" };
            _mockService.Setup(repo => repo.AddArtist(artist))
                .ReturnsAsync(artist);

            // Act
            var result = await _controller.Add(artist);

            // Assert
            var createdResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal(artist, createdResult.Value);
        }
    }
}
