using System;
using System.Collections.Generic;
using System.Text;

namespace AtosLibrary.Presentation.BookItem
{
    public interface IBookItemPresentationRepository
    {
        BookItemModel Get(Guid id);

        IEnumerable<BookItemModel> GetList();

        IEnumerable<BookItemModel> GetListByBookId(Guid bookId);

        bool IsInstanceOfBook(Guid bookId, Guid id);
    }
}
