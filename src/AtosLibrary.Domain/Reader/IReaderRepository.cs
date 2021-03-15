using System;
using System.Collections.Generic;
using AtosLibrary.Infrastructure;
using AtosLibrary.Infrastructure.Entities;

namespace AtosLibrary.Domain.Reader
{
    public interface IReaderRepository
    {
        void Save(ReaderEntity readerEntity);

        void Edit(ReaderEntity readerEntity);

        void Delete(Guid id);

        ReaderEntity Get(Guid id);

        IEnumerable<ReaderEntity> GetList();
    }
}