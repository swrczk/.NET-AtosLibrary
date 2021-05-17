using System;
using AtosLibrary.Infrastructure.Entities;

namespace AtosLibrary.Presentation.Reader
{
    using System.ComponentModel.DataAnnotations;

    using AtosLibrary.Infrastructure;

    public class ReaderModel
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(15)]
        public string Name { get; set; }
        [Required]
        [MaxLength(15)]
        public string Surname { get; set; }
        [Required]
        [MaxLength(15)]
        public string Country { get; set; }
        [Required]
        [MaxLength(15)]
        public string City { get; set; }

        public string ZipCode { get; set; }
    }
}