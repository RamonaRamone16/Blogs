using System;
using System.Collections.Generic;

namespace Blogs.DAL.Entities
{
    public class Theme : IEntity
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public User Author { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PublishedDate { get; set; }
        public ICollection<Record> Records { get; set; }
    }
}
