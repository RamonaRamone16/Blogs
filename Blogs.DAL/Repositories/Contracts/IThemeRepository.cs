using Blogs.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blogs.DAL.Repositories.Contracts
{
    public interface IThemeRepository : IRepository<Theme>
    {
        IEnumerable<Theme> GetAllWithAuthorsAndRecords();
        IEnumerable<Theme> GetWithAuthorsAndRecords(int themeId);
    }
}
