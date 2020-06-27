using Blogs.DAL.Entities;
using Blogs.DAL.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blogs.DAL.Repositories
{
    public class ThemeRepository : Repository<Theme>, IThemeRepository
    {
        public ThemeRepository(ApplicationDbContext context) : base(context)
        {
            entities = context.Themes;
        }

        public IEnumerable<Theme> GetAllWithAuthorsAndRecords()
        {
            return entities.Include(t => t.Author).Include(t => t.Records).ThenInclude(r => r.Author);
        }

        public IEnumerable<Theme> GetWithAuthorsAndRecords(int themeId)
        {
            return entities.Include(t => t.Author).Include(t => t.Records).ThenInclude(r => r.Author);
        }
    }
}
