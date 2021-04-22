using System;
using System.ComponentModel.DataAnnotations;

namespace ContactManager.Models
{
    public class Book
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }
        public String Reader { get; set; }
        public DateTime ReturnDate { get; set; }
        public Boolean Rented { get; set; }
    }
}
