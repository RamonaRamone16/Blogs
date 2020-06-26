using Blogs.DAL.Entities;
using Blogs.DAL.Repositories.Contracts;

namespace Blogs.DAL.Repositories
{
    public class RecordRepository : Repository<Record>, IRecordRepository
    {
        public RecordRepository(ApplicationDbContext context) : base(context)
        {
            entities = context.Records;
        }
    }
}
