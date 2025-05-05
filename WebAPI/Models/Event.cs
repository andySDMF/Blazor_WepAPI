namespace WebAPI.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public DateTime Start {  get; set; }
        public DateTime? End { get; set; }
        public bool AllDay { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
