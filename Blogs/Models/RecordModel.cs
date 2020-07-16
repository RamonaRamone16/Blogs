namespace Blogs.Models
{
    public class RecordModel
    {
        public int Id { get; set; }
        public string AuthorName { get; set; }
        public int ThemeId { get; set; }
        public string Content { get; set; }
        public string PublishedDate { get; set; }
        public int AuthorAnswersCount { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
    }
}
