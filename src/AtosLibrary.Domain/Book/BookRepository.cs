using System;
using System.Collections.Generic;
using AtosLibrary.Infrastructure;
using AtosLibrary.Infrastructure.Entities;
using AtosLibrary.Infrastructure.InMemory;

namespace AtosLibrary.Domain.Book
{
    public class BookRepository : IBookRepository
    {
        private readonly IInMemoryDb<BookEntity> _inMemory;
        
        public BookRepository(IInMemoryDb<BookEntity> inMemory)
        {
            _inMemory = inMemory;
        }

        public void Save(BookEntity bookEntity)
        {
            _inMemory.Add(bookEntity);
        }

        public BookEntity Get(Guid bookId)
        {
            return _inMemory.Get(bookId);
        }

        public IEnumerable<BookEntity> GetList()
        {
            return _inMemory.GetAll();
        }

        public void Edit(BookEntity bookEntity)
        {
            _inMemory.Edit(bookEntity);
        }

        public void Delete(Guid id)
        {
            _inMemory.Delete(id);
        }
    }
}