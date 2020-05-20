using System;

namespace Tax.Core.Repositories
{
    public interface IRepository<T> 
    {
        T Get(Guid Id);

        T Add(T entity);

        void SaveChanges();

    }
}
