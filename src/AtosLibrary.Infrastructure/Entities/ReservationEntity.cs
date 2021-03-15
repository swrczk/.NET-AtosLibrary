using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtosLibrary.Infrastructure.Entities
{
    [Table("Reservations")]
    public class ReservationEntity
    {
        public Guid Id { get; set; }
        public Guid BookItemId { get; set; }
        public Guid ReaderId { get; set; }
        public DateTime DateBeginOfReservation { get; set; }
        public DateTime? DateEndOfReservation { get; set; }
        public EnumStatusReservation Status { get; set; }

        public ReservationEntity(Guid bookItemId, Guid readerId, Guid id, DateTime dateBeginOfReservation,
            EnumStatusReservation status, DateTime? dateEndOfReservation = null)
        {
            Id = id;
            BookItemId = bookItemId;
            ReaderId = readerId;
            DateBeginOfReservation = dateBeginOfReservation;
            DateEndOfReservation = dateEndOfReservation;
            Status = status;
        }

        public virtual BookItemEntity BookItem { get; set; }

        public virtual ReaderEntity Reader { get; set; }
    }
}
