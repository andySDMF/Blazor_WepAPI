using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Models
{
    public class PhotoDto
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public int CategoryId { get; set; }
    }
}
