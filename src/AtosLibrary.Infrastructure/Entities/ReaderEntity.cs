using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtosLibrary.Infrastructure.Entities
{
    [Table("Readers")]
    public class ReaderEntity
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }
        
        public string Surname { get; set; }
        
        public string Country { get; set; }
        
        public string City { get; set; }

        public ReaderEntity(Guid id, string name, string surname, string country, string city)
        {
            
            Id = id;
            Name = name;
            Surname = surname;
            Country = country;
            City = city;
        }

        public virtual ICollection<ReservationEntity> ReservationEntities { get; set; } = new HashSet<ReservationEntity>();
    }

}