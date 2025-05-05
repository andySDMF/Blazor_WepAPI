using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class PhotoDto
    {
        [Required]
        public string Title { get; set; } = string.Empty;

        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;

        [Required]
        public string ImageUrl { get; set; } = string.Empty;

        [Required]
        public int CategoryId { get; set; }
    }
}
