using System;
using AtosLibrary.Infrastructure.Entities;

namespace AtosLibrary.Domain.BookItem
{
    public interface IBookItemFactory
    {
        BookItem Create(Guid bookId);

        BookItem CloneBookItem(Guid id, Guid bookId, string description, EnumBookItemStatus status);
    }
}
