using System;
using System.Collections.Generic;
using System.Text;
using AtosLibrary.Infrastructure.Entities;

namespace AtosLibrary.Domain.BookItem
{
    public interface IBookItemRepository
    {
        void Save(BookItemEntity bookItemEntity);

        void Edit(BookItemEntity bookItemEntity);

        void Delete(Guid id);

        IEnumerable<BookItemEntity> GetList();

        BookItemEntity Get(Guid id);

        IEnumerable<BookItemEntity> GetListByBookId(Guid bookId);
    }
}
