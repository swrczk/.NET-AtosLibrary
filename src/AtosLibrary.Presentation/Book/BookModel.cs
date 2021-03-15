using System;
using AtosLibrary.Infrastructure.Entities;

namespace AtosLibrary.Presentation.Book
{
    using System.ComponentModel.DataAnnotations;

    using AtosLibrary.Infrastructure;

    public class BookModel
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }
        [Required]
        [Range(0, 2000)]
        public int Number { get; set; }
        
    }
}