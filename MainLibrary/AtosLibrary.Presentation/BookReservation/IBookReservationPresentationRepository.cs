using System;
using System.Collections.Generic;
using System.Text;

namespace AtosLibrary.Presentation.BookReservation
{
    public interface IBookReservationPresentationRepository
    {
        IEnumerable<BookReservationModel> GetPossibleList();

        IEnumerable<BookReservationModel> GetSearchList(string searchText);

        IEnumerable<BookReservationModel> Search(string searchText);

        bool IsReservedByReader(Guid bookId, Guid readerId);

        bool IsPossibleToReserve(Guid bookId);

        int GetNumberOfCurrentReservations(Guid bookId);

        int GetNumberOfAllBookItems(Guid bookId);

        int GetNumberOfAvailableBooks(Guid bookId);

        BookReservationModel GetFirstAvailable(Guid bookId);
    }
}
