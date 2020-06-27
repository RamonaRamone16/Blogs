namespace Blogs.Models
{
    public class ThemeModel
    {
        public int Id { get; set; }
        public string AuthorName { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string PublishedDate { get; set; }
        public int RecordsCount { get; set; }
    }
}
