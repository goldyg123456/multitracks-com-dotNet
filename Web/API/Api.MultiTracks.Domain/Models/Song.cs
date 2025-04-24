using System.ComponentModel.DataAnnotations;

namespace Api.MultiTracks.Domain.Models
{
    public class Song
    {
        [Key]
        public int SongID { get; set; }

        [Required]
        [MaxLength(255, ErrorMessage = "The song title cannot exceed 255 characters.")]
        public required string Title { get; set; }

        public int BPM { get; set; }

        [MaxLength(50, ErrorMessage = "The time signature cannot exceed 50 characters.")]
        public required string TimeSignature { get; set; }

        [MaxLength(500, ErrorMessage = "The song ImageURL cannot exceed 500 characters.")]
        public required string ImageURL { get; set; }
    }
}
