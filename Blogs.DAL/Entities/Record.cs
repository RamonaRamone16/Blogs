using System;
using System.Collections.Generic;
using System.Text;

namespace Blogs.DAL.Entities
{
    public class Record : IEntity
    {
        public int Id { get ; set ; }
        public int AuthorId { get; set; }
        public User Author { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PublishedDate { get; set; }
    }
}
