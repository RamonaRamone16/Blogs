using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Blogs.DAL.Entities
{
    public class User : IdentityUser<int>, IEntity
    {
        public ICollection<Record> Records { get; set; }
        public ICollection<Theme> Themes { get; set; }
    }
}
