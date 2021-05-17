using System.ComponentModel.DataAnnotations;

namespace AtosLibrary.Application.Features.RegistrationReader
{
    public class RegistrationReaderCommand
    {
        public RegistrationReaderCommand(string name, string surname, string country, string city, string zipCode)
        {
            Name = name;
            Surname = surname;
            Country = country;
            City = city;
            ZipCode = zipCode;
        }
        public string Name { get; }
        public string Surname { get; }
        public string Country { get; }
        public string City { get; }
        public string ZipCode { get; }
    }
}