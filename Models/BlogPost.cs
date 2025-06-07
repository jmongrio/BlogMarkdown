namespace BlogMarkDown.Models
{
    public class BlogPost
    {
        public string Title { get; set; } = null!;
        public string Slug { get; set; } = null!;
        public string ContentHtml { get; set; } = null!;
        public DateTime LastModified { get; set; }
    }
}