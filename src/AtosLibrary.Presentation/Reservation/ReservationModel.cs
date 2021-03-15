using System;
using AtosLibrary.Infrastructure.Entities;

namespace AtosLibrary.Presentation.Reservation
{
    public class ReservationModel
    {
        public Guid Id { get; set; }
        public Guid BookItemId { get; set; }
        public Guid ReaderId { get; set; }
        public EnumStatusReservation Status { get; set; }
        public string BookName { get; set; }
        public string ReaderName { get; set; }
        public DateTime DateBeginOfReservation { get; set; }
        public DateTime? DateEndOfReservation { get; set; }
    }

}
