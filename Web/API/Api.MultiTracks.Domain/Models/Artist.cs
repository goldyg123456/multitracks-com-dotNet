using System.ComponentModel.DataAnnotations;

namespace Api.MultiTracks.Domain.Models
{
    public class Artist
    {
        [Key]
        public int ArtistID { get; set; }

        [Required]
        [MaxLength(255, ErrorMessage = "The artist title cannot exceed 255 characters.")]
        public required string Title { get; set; }

        [MaxLength(2000, ErrorMessage = "The biography cannot exceed 2000 characters.")]
        public required string Biography { get; set; }

        [MaxLength(500, ErrorMessage = "The image URL cannot exceed 500 characters.")]
        public required string ImageURL { get; set; }

        [MaxLength(500, ErrorMessage = "The hero URL cannot exceed 500 characters.")]
        public required string HeroURL { get; set; }
    }
}
