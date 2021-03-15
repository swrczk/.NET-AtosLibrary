using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AtosLibrary.Infrastructure.Entities
{
    [Table("BookItems")]
    public class BookItemEntity
    {
        public Guid Id { get; set; }
        public Guid BookId { get; set; }
        public string Description { get; set; }
        public EnumBookItemStatus BookItemStatus { get; set; } 
        public BookItemEntity(Guid id, Guid bookId, string description, EnumBookItemStatus bookItemStatus = EnumBookItemStatus.Available)
        {
            Id = id;
            BookId = bookId;
            Description = description;
            BookItemStatus = bookItemStatus;
        }

        public virtual BookEntity Book { get; set; }

        public virtual ICollection<ReservationEntity> ReservationEntities { get; set; } = new HashSet<ReservationEntity>();

    }
}
