using Blogs.DAL.Entities;
using Blogs.DAL.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Blogs.DAL.Repositories
{
    public class RecordRepository : Repository<Record>, IRecordRepository
    {
        public RecordRepository(ApplicationDbContext context) : base(context)
        {
            entities = context.Records;
        }

        public IEnumerable<Record> GetAllWithAuthors(int id)
        {
            return entities.Include(r => r.Author).Where(r => r.Theme.Id == id);
        }
    }
}
