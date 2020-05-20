using System;
using System.Linq;
using Tax.Core.Entities;
using Tax.Core.Repositories;

namespace Tax.Persistence.EF
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly TaxContext _context;
        private bool disposed = false;

        public BaseRepository(TaxContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public T Add(T entity)
        {
            return _context.Set<T>().Add(entity).Entity;
        }

        public T Get(Guid Id)
        {
            return _context.Set<T>().FirstOrDefault(x => x.Id == Id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
