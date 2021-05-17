using System;

namespace AtosLibrary.Domain.Book
{
    public class BookFactory : IBookFactory
    {
        public Book Create(string name, string description, int number)
        {
            return new Book(name, description, number);
        }
        public Book Create(Guid id, string name, string description, int number)
        {
            return new Book(id, name, description, number);
        }

        public Book Create(Guid bookId, IBookRepository bookRepository)
        {
            return new Book(bookId, bookRepository);
        }
    }
}