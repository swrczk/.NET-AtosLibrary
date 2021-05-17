using System;
using System.Collections.Generic;
using System.Linq;
using AtosLibrary.Domain.Book;
using AtosLibrary.Domain.BookItem;
using AtosLibrary.Domain.Reader;
using AtosLibrary.Domain.Reservation;

namespace AtosLibrary.Presentation.Reservation
{
    public class ReservationPresentationRepository : IReservationPresentationRepository
    {
        private readonly IBookRepository _bookRepository;
        private readonly IBookItemRepository _bookItemRepository;
        private readonly IReaderRepository _readerRepository;
        private readonly IReservationRepository _reservationRepository;

        public ReservationPresentationRepository(IBookRepository bookRepository, IReaderRepository readerRepository, IReservationRepository reservationRepository, IBookItemRepository bookItemRepository)
        {
            _bookRepository = bookRepository;
            _readerRepository = readerRepository;
            _reservationRepository = reservationRepository;
            _bookItemRepository = bookItemRepository;
        }

        public ReservationModel Get(Guid id)
        {
            var reservationEntity = _reservationRepository.Get(id);
            var readerEntity = _readerRepository.Get(reservationEntity.ReaderId);
            var bookItemEntity = _bookItemRepository.Get(reservationEntity.BookItemId);
            var bookEntity = _bookRepository.Get(bookItemEntity.BookId);

            ReservationModel reservation = new ReservationModel
            {

                Id = reservationEntity.Id,
                ReaderId = reservationEntity.ReaderId,
                BookItemId = reservationEntity.BookItemId,
                Status = reservationEntity.Status,
                ReaderName = readerEntity.Name,
                BookName = bookEntity.Name,
                DateBeginOfReservation = reservationEntity.DateBeginOfReservation,
                DateEndOfReservation = reservationEntity.DateEndOfReservation
            };

            return reservation;
        }

        public IEnumerable<ReservationModel> GetList()
        {
            var entities = _reservationRepository.GetList();
            var reservations = new List<ReservationModel>();

            foreach (var entity in entities)
            {
                ReservationModel reservation = Get(entity.Id);
                
                reservations.Add(reservation);
            }

            return reservations;
        }

        public IEnumerable<ReservationModel> GetSearchList(string searchText)
        {
            var reservationEntities = _reservationRepository.GetList();
            var reservations = new List<ReservationModel>();
            var keyWords = searchText?.Split(" ");

            foreach (var reservationEntity in reservationEntities)
            {
                if ((keyWords ?? throw new InvalidOperationException()).Any(x => _readerRepository.Get(reservationEntity.ReaderId).Name.ToLower().Contains(x.ToLower()) || _bookRepository.Get(reservationEntity.BookItemId).Name.ToLower().Contains(x.ToLower())))
                {
                    ReservationModel reservation = Get(reservationEntity.Id);
                    reservations.Add(reservation);
                }

            }

            return reservations;
        }

        public IEnumerable<ReservationModel> Search(string searchText)
        {
            return searchText == null ? GetList() : GetSearchList(searchText);
        }

    }
}
