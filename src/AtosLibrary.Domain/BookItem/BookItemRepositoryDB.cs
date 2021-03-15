using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using AtosLibrary.Infrastructure.Entities;
using AtosLibrary.Infrastructure.SQLDataBase;

namespace AtosLibrary.Domain.BookItem
{
    public class BookItemRepositoryDB : IBookItemRepository
    {
        private readonly AtosLibraryContext _context;

        public BookItemRepositoryDB(AtosLibraryContext context)
        {
            _context = context;
        }

        public void Save(BookItemEntity bookItemEntity)
        {
            this._context.BookItem.Add(bookItemEntity);
            this._context.SaveChanges();
        }

        public void Edit(BookItemEntity bookItemEntity)
        {
            var entity = Get(bookItemEntity.Id);
            entity.Id = bookItemEntity.Id;
            entity.BookId = bookItemEntity.BookId;
            entity.Description = bookItemEntity.Description;
            entity.BookItemStatus = bookItemEntity.BookItemStatus;
            this._context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var entity = Get(id);
            entity.BookItemStatus = EnumBookItemStatus.Deleted;
            this._context.SaveChanges();
        }

        public IEnumerable<BookItemEntity> GetList()
        {
            return this._context.BookItem.ToList();
        }

        public BookItemEntity Get(Guid id)
        {
            return this._context.BookItem.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<BookItemEntity> GetListByBookId(Guid bookId)
        {
            return this._context.BookItem.Where(x => x.BookId == bookId);
        }
    }
}
