using System;

namespace AtosLibrary.Domain.Book
{
    public interface IBookFactory
    {
        Book Create(string name, string description, int number);
        Book Create(Guid id, string name, string description, int number);
        Book Create(Guid bookId, IBookRepository bookRepository);
    }
}