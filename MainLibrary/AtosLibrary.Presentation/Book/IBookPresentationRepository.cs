using System;
using System.Collections.Generic;

namespace AtosLibrary.Presentation.Book
{
    public interface IBookPresentationRepository
    {
        BookModel Get(Guid id);
        IEnumerable<BookModel> GetList();
        IEnumerable<BookModel> Search(string searchText);
    }
}