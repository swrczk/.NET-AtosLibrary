using System;
using System.Collections.Generic;
using System.Linq;
using AtosLibrary.Domain.Book;
using AtosLibrary.Domain.BookItem;
using AtosLibrary.Domain.Reservation;
using AtosLibrary.Infrastructure.Entities;

namespace AtosLibrary.Presentation.BookReservation
{
    public class BookReservationPresentationRepository : IBookReservationPresentationRepository
    {
        private readonly IBookRepository _bookRepository;
        private readonly IReservationRepository _reservationRepository;
        private readonly IBookItemRepository _bookItemRepository;

        public BookReservationPresentationRepository(IBookRepository bookRepository, IReservationRepository reservationRepository, IBookItemRepository bookItemRepository)
        {
            _bookRepository = bookRepository;
            _reservationRepository = reservationRepository;
            _bookItemRepository = bookItemRepository;
        }

        public IEnumerable<BookReservationModel> GetSearchList(string searchText)
        {
            var bookEntities = _bookRepository.GetList();
            var bookReservations = new List<BookReservationModel>();
            var keyWords = searchText?.Split(" ");

            foreach (var bookEntity in bookEntities)
            {
                if ((keyWords ?? throw new InvalidOperationException()).Any(x => _bookRepository.Get(bookEntity.Id).Name.ToLower().Contains(x.ToLower())))
                    if (IsPossibleToReserve(bookEntity.Id))
                    {
                        BookReservationModel bookReservation = GetFirstAvailable(bookEntity.Id);
                        if (bookReservation != null)
                        {
                            bookReservations.Add(bookReservation);
                        }
                    }
            }

            return bookReservations;
        }

        public IEnumerable<BookReservationModel> Search(string searchText)
        {
            return searchText == null ? GetPossibleList() : GetSearchList(searchText);
        }
        

        public IEnumerable<BookReservationModel> GetPossibleList()
        {
            var bookEntities = _bookRepository.GetList();
            var bookReservations = new List<BookReservationModel>();

            foreach (var bookEntity in bookEntities)
            {
                if (IsPossibleToReserve(bookEntity.Id))
                {
                    BookReservationModel bookReservation = GetFirstAvailable(bookEntity.Id);
                    if (bookReservation != null)
                    {
                        bookReservations.Add(bookReservation);
                    }
                }
            }

            return bookReservations;
        }

        public bool IsReservedByReader(Guid bookId, Guid readerId)
        {
            var reservationEntities = _reservationRepository.GetList();
            var readersReservations = reservationEntities.Where(reservation =>
                reservation.BookItemId == bookId && reservation.ReaderId == readerId);
            foreach (var readerReservation in readersReservations)
            {
                if (readerReservation.Status != EnumStatusReservation.Returned)
                    return true;
            }
            return false;
        }

        public bool IsPossibleToReserve(Guid bookId)
        {
            var bookEntities = _bookRepository.GetList();
            if (bookEntities != null)
            {
                int numberOfBooksInStore = GetNumberOfAllBookItems(bookId);
                if (numberOfBooksInStore == GetNumberOfCurrentReservations(bookId))
                {
                    return false;
                }
            }
            return true;
        }

        public int GetNumberOfAvailableBooks(Guid bookId)
        {
            return GetNumberOfAllBookItems(bookId) - GetNumberOfCurrentReservations(bookId);
        }

        public BookReservationModel GetFirstAvailable(Guid bookId)
        {
            var bookEntity = _bookRepository.Get(bookId);
            var itemEntities = _bookItemRepository.GetList();
            var bookItemFirstAvailable = itemEntities.FirstOrDefault(x => x.BookId == bookId && x.BookItemStatus == EnumBookItemStatus.Available);
            if (bookItemFirstAvailable != null)
            {
                BookReservationModel bookReservation = new BookReservationModel
                {
                    BookItemId = bookItemFirstAvailable.Id,
                    BookId = bookItemFirstAvailable.BookId,
                    BookName = bookEntity.Name,
                    NumberOfAvailableBooks = GetNumberOfAvailableBooks(bookId)
                };
                return bookReservation;
            }

            return null;
        }

        public int GetNumberOfCurrentReservations(Guid bookId)
        {
            var reservationEntities = _reservationRepository.GetList();
            var bookItemEntities = _bookItemRepository.GetList();
            var bookItems = bookItemEntities.Where(x => x.BookId == bookId).Select(x => x.Id);
            var numberOfCurrentlyRentedBooks = reservationEntities.Count(x => bookItems.Contains(x.BookItemId) && x.Status != EnumStatusReservation.Returned);
            return numberOfCurrentlyRentedBooks;
        }

        public int GetNumberOfAllBookItems(Guid bookId)
        {
            var bookItemEntities = _bookItemRepository.GetList();
            var numberOfCurrentlyRentedBooks = bookItemEntities.Count(x => x.BookId == bookId && x.BookItemStatus != EnumBookItemStatus.Deleted);
            return numberOfCurrentlyRentedBooks;
        }
    }
}
