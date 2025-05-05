namespace BlazorApp.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public DateTime CreatedAt { get; set; }

        public PhotoCategory? Category { get; set; }
    }
}
