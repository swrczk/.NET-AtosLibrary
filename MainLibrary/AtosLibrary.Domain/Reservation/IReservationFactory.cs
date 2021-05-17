using System;

namespace AtosLibrary.Domain.Reservation
{
    public interface IReservationFactory
    {
        Reservation Create(Guid bookItemId, Guid readerId);
        Reservation Create(Guid bookItemId, Guid readerId, Guid id);
        Reservation Clone(IReservationRepository reservationRepository, Guid id);
    }
}
