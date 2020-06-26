using Blogs.DAL.Repositories;
using Blogs.DAL.Repositories.Contracts;
using System;

namespace Blogs.DAL
{
    public class UnitOfWork : IDisposable
    {
        private readonly ApplicationDbContext _context;

        private bool disposed;

        public IRecordRepository Records { get; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Records = new RecordRepository(context);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
                _context.Dispose();

            disposed = true;
        }
        ~UnitOfWork()
        {
            Dispose(false);
        }
    }
}
