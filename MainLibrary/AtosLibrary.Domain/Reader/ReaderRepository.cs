using System;
using System.Collections.Generic;
using AtosLibrary.Infrastructure;
using AtosLibrary.Infrastructure.Entities;
using AtosLibrary.Infrastructure.InMemory;

namespace AtosLibrary.Domain.Reader
{
    public class ReaderRepository : IReaderRepository
    {
        private readonly IInMemoryDb<ReaderEntity> _inMemory;

        public ReaderRepository(IInMemoryDb<ReaderEntity> inMemory)
        {
            _inMemory = inMemory;
        }

        public void Save(ReaderEntity readerEntity)
        {
            _inMemory.Add(readerEntity);
        }

        public void Edit(ReaderEntity readerEntity)
        {
            _inMemory.Edit(readerEntity);
        }

        public void Delete(Guid id)
        {
            _inMemory.Delete(id);
        }

        public ReaderEntity Get(Guid id)
        {
            return _inMemory.Get(id);
        }

        public IEnumerable<ReaderEntity> GetList()
        {
            return _inMemory.GetAll();
        }
    }
}