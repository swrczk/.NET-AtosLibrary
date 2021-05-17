using System;

namespace AtosLibrary.Application.Features.ReturnBook
{
    public class ReturnBookCommand
    {
        public ReturnBookCommand(Guid reservationId)
        {
            ReservationId = reservationId;
        }
        public Guid ReservationId { get; set; }
    }
}