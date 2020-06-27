namespace Blogs.Models
{
    public class RecordModel
    {
        public int Id { get; set; }
        public string AuthorName { get; set; }
        public ThemeModel Theme { get; set; }
        public string Content { get; set; }
        public string PublishedDate { get; set; }
    }
}
