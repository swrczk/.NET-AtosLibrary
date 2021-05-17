using System;
using System.Collections.Generic;
using AtosLibrary.Infrastructure;
using AtosLibrary.Infrastructure.Entities;

namespace AtosLibrary.Domain.Book
{
    public interface IBookRepository
    {
        void Save(BookEntity bookEntity);
        BookEntity Get(Guid bookId);
        IEnumerable<BookEntity> GetList();

        void Edit(BookEntity bookEntity);

        void Delete(Guid id);
    }
}