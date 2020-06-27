using Blogs.DAL.Entities;
using System.Collections.Generic;

namespace Blogs.DAL.Repositories.Contracts
{
    public interface IRecordRepository : IRepository<Record>
    {
        IEnumerable<Record> GetAllWithAuthors(int id);
    }
}
