namespace AtosLibrary.Application.Features.EditReader
{
    using System;

    public class EditReaderCommand
    {
        public EditReaderCommand(Guid id, string name, string surname, string country, string city, string zipCode)
        {
            this.Id = id;
            Name = name;
            Surname = surname;
            Country = country;
            City = city;
            ZipCode = zipCode;
        }

        public Guid Id { get; set; }

        public string Name { get; }
        public string Surname { get; }
        public string Country { get; }
        public string City { get; }
        public string ZipCode { get; }
    }
}