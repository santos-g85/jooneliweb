namespace jooneliweb.Models
{
    public class NewsViewModel
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public string Category { get; set; }

        public string Image { get; set; }

        public bool IsFeatured { get; set; } = false;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
