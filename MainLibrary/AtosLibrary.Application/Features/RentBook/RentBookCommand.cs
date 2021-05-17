using System;

namespace AtosLibrary.Application.Features.RentBook
{
    public class RentBookCommand
    {
        public RentBookCommand(Guid bookItemId, Guid readerId, Guid reservationId)
        {
            ReservationId = reservationId;
            BookItemId = bookItemId;
            ReaderId = readerId;
        }
        public Guid ReservationId { get; set; }
        public Guid BookItemId { get; set; }
        public Guid ReaderId { get; set; }
    }
}