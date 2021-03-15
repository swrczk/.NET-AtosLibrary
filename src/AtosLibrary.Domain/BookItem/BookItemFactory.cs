using System;
using System.Collections.Generic;
using System.Text;
using AtosLibrary.Infrastructure.Entities;

namespace AtosLibrary.Domain.BookItem
{
    public class BookItemFactory : IBookItemFactory
    {
        public BookItem Create(Guid bookId)
        {
            return new BookItem(bookId);
        }

        public BookItem CloneBookItem(Guid id, Guid bookId, string description, EnumBookItemStatus status)
        {
            return new BookItem(id, bookId, description, status);
        }
    }
}
