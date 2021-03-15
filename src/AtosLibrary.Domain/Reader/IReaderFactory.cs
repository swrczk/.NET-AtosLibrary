namespace AtosLibrary.Domain.Reader
{
    using System;

    public interface IReaderFactory
    {
        Reader Create(string commandName, string commandSurname, string commandCountry, string commandCity, string commandZipCode);
        Reader Create(Guid commandId, string commandName, string commandSurname, string commandCountry, string commandCity, string commandZipCode);
    }
}