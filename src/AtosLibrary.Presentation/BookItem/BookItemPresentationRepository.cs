using System;
using System.Collections.Generic;
using System.Text;
using AtosLibrary.Domain.BookItem;

namespace AtosLibrary.Presentation.BookItem
{
    public class BookItemPresentationRepository : IBookItemPresentationRepository
    {
        private readonly IBookItemRepository _bookItemRepository;

        public BookItemPresentationRepository(IBookItemRepository bookItemRepository)
        {
            _bookItemRepository = bookItemRepository;
        }


        public BookItemModel Get(Guid id)
        {
            BookItemModel bookItemModel = new BookItemModel();
            var entity = _bookItemRepository.Get(id);
            bookItemModel.Id = entity.Id;
            bookItemModel.BookId = entity.BookId;
            bookItemModel.Description = entity.Description;
            bookItemModel.BookItemStatus = entity.BookItemStatus;

            return bookItemModel;
        }

        public IEnumerable<BookItemModel> GetList()
        {
            var entities = _bookItemRepository.GetList();

            var bookItems = new List<BookItemModel>();

            foreach (var entity in entities)
            {
                var bookItemModel = new BookItemModel();

                bookItemModel.Id = entity.Id;
                bookItemModel.BookId = entity.BookId;
                bookItemModel.Description = entity.Description;
                bookItemModel.BookItemStatus = entity.BookItemStatus;

                bookItems.Add(bookItemModel);
            }

            return bookItems;
        }

        public IEnumerable<BookItemModel> GetListByBookId(Guid bookId)
        {
            var entities = _bookItemRepository.GetList();

            var bookItems = new List<BookItemModel>();

            foreach (var entity in entities)
            {
                if (IsInstanceOfBook(bookId, entity.Id))
                {
                    var bookItemModel = new BookItemModel();

                    bookItemModel.Id = entity.Id;
                    bookItemModel.BookId = entity.BookId;
                    bookItemModel.Description = entity.Description;
                    bookItemModel.BookItemStatus = entity.BookItemStatus;

                    bookItems.Add(bookItemModel);
                }
            }
            return bookItems;
        }

        public bool IsInstanceOfBook(Guid bookId, Guid id)
        {
            BookItemModel bookItemModel = Get(id);
            return bookItemModel.BookId == bookId;
        }
    }
}
