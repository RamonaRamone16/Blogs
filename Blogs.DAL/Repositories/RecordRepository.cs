using Blogs.DAL.Entities;
using Blogs.DAL.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Blogs.DAL.Repositories
{
    public class RecordRepository : Repository<Record>, IRecordRepository
    {
        public RecordRepository(ApplicationDbContext context) : base(context)
        {
            entities = context.Records;
        }

        public IEnumerable<Record> GetAllWithAuthors()
        {
            return entities.Include(r => r.Author);
        }
    }
}
