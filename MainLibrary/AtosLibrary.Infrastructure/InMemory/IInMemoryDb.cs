using System;
using System.Collections.Generic;

namespace AtosLibrary.Infrastructure.InMemory
{
    public interface IInMemoryDb<T>
    {
        T Get(Guid id);
        IEnumerable<T> GetAll();
        void Add(T entity);
        void Delete(Guid id);
        void Edit(T entity);
    }
}