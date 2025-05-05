using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class PhotoCategoryDto
    {
        [Required]
        public string Name { get; set; } = "";
    }
}
