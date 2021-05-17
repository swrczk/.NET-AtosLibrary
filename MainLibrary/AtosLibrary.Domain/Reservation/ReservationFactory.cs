using System;
using System.Collections.Generic;
using System.Text;

namespace AtosLibrary.Domain.Reservation
{
    public class ReservationFactory : IReservationFactory
    {
        public Reservation Create(Guid bookItemId, Guid readerId)
        {
            return new Reservation(bookItemId, readerId);
        }

        public Reservation Create(Guid bookItemId, Guid readerId, Guid id)
        {
            return new Reservation(bookItemId, readerId, id);
        }

        public Reservation Clone(IReservationRepository reservationRepository, Guid id)
        {
            Reservation clone = new Reservation();
            return clone.Clone(reservationRepository, id);
        }
    }
}
