using System;
using AtosLibrary.Infrastructure.Entities;

namespace AtosLibrary.Domain.Reservation
{
    public class Reservation
    {
        private readonly Guid _id;
        private readonly Guid _bookItemId;
        private readonly Guid _readerId;
        private DateTime DateBeginOfReservation { get; set; }
        private DateTime DateEndOfReservation { get; set; }
        private readonly EnumStatusReservation _status;

        public Reservation()
        {
            _id = Guid.NewGuid();
        }
        public Reservation(Guid bookItemId, Guid readerId)
        {
            _id = Guid.NewGuid();
            _bookItemId = bookItemId;
            _readerId = readerId;
            _status = EnumStatusReservation.Reserved;
            DateBeginOfReservation = DateTime.Today;
        }

        public Reservation(Guid bookItemId, Guid readerId, Guid id)
        {
            _id = id;
            _bookItemId = bookItemId;
            _readerId = readerId;
            _status = EnumStatusReservation.Rented;
            DateBeginOfReservation = DateTime.Today;
        }

        public Reservation(Guid bookItemId, Guid readerId, Guid id, DateTime beginReservation)
        {
            _id = id;
            _bookItemId = bookItemId;
            _readerId = readerId;
            _status = EnumStatusReservation.Returned;
            DateBeginOfReservation = beginReservation;
            DateEndOfReservation = DateTime.Today;
        }

        public Reservation Clone(IReservationRepository reservationRepository, Guid id)
        {
            var reservation = reservationRepository.Get(id);
            return new Reservation(reservation.BookItemId, reservation.ReaderId, reservation.Id, reservation.DateBeginOfReservation);
        }

        public void Reserve(IReservationRepository reservationRepository)
        {
            reservationRepository.Save(new ReservationEntity(_bookItemId, _readerId, _id, DateTime.Today, EnumStatusReservation.Reserved));
        }

        public void Rent(IReservationRepository reservationRepository)
        {
            reservationRepository.Edit(new ReservationEntity(_bookItemId, _readerId, _id, DateTime.Today, EnumStatusReservation.Rented));
        }

        public void Return(IReservationRepository reservationRepository)
        {
            reservationRepository.Edit(new ReservationEntity(_bookItemId, _readerId, _id, DateBeginOfReservation, EnumStatusReservation.Returned, DateTime.Now));
        }
    }
}
