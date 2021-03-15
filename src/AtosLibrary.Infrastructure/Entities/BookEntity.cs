using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtosLibrary.Infrastructure.Entities
{
    [Table("Books")]
    public class BookEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Number { get; set; }
        [NotMapped]
        public List<Guid> Readers { get; set; }

        public BookEntity(Guid id, string name, string description, int number, List<Guid> reader)
        {
            Id = id;
            Name = name;
            Description = description;
            Number = number;
            Readers = reader;
        }
        public BookEntity(Guid id, string name, string description, int number)
        {
            Id = id;
            Name = name;
            Description = description;
            Number = number;
            Readers = new List<Guid>();
        }

        

        public virtual ICollection<BookItemEntity> BookItems { get; set; } = new HashSet<BookItemEntity>();
    }
}