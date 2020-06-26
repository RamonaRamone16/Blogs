using Blogs.DAL.Entities;
using Blogs.DAL.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Blogs.DAL.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        private ApplicationDbContext _context;
        protected DbSet<T> entities;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public T Create(T entity)
        {
            var entryEntity = entities.Add(entity);
            _context.SaveChanges();
            return entryEntity.Entity;
        }
        public T GetById(int id)
        {
            return entities.FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<T> GetAll()
        {
            return entities.ToList();
        }

        public void Remove(T entity)
        {
            entities.Remove(entity);
            _context.SaveChanges();
        }

        public T Update(T entity)
        {
            var entryEntity = entities.Update(entity);
            _context.SaveChanges();
            return entryEntity.Entity;
        }
    }
}
