namespace AtosLibrary.Domain.Reader
{
    using System;

    public class ReaderFactory : IReaderFactory
    {
        public Reader Create(string commandName, string commandSurname, string commandCountry, string commandCity, string commandZipCode)
        {
            return new Reader(commandName, commandSurname, commandCountry, commandCity, commandZipCode);
        }

        public Reader Create(Guid commandId, string commandName, string commandSurname, string commandCountry, string commandCity, string commandZipCode)
        {
            return new Reader(commandId, commandName, commandSurname, commandCountry, commandCity, commandZipCode);
        }
    }
}