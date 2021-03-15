 using System;
using System.Collections.Generic;
using System.Text;
using AtosLibrary.Infrastructure.Entities;

namespace AtosLibrary.Domain.BookItem
{
    public class BookItem
    {
        private readonly Guid _id;
        private readonly Guid _bookId;
        private readonly string _description;
        private EnumBookItemStatus _status;
        

        public BookItem(Guid bookId, EnumBookItemStatus status = EnumBookItemStatus.Available)
        {
            _id = Guid.NewGuid();
            _bookId = bookId;
            _description = "";
            _status = status;
        }

        public BookItem(Guid id, Guid bookId, string description, EnumBookItemStatus status)
        {
            _id = id;
            _bookId = bookId;
            _description = description;
            _status = status;
        }

        public BookItemEntity MakeEntity()
        {
            return new BookItemEntity(this._id, this._bookId, this._description, this._status);
        }


        public void Edit(IBookItemRepository bookItemRepository)
        {
            bookItemRepository.Edit(new BookItemEntity(_id, _bookId, _description, _status));
        }
    }
}
