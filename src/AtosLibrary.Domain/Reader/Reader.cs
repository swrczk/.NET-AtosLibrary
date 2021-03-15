using System;
using AtosLibrary.Infrastructure;
using AtosLibrary.Infrastructure.Entities;

namespace AtosLibrary.Domain.Reader
{
    public class Reader
    {
        private readonly Guid _id;
        private readonly string _commandName;
        private readonly string _commandSurname;
        private readonly string _commandCountry;
        private readonly string _commandCity;
        private readonly string _commandZipCode;

        internal Reader(string commandName, string commandSurname, string commandCountry, string commandCity, string commandZipCode)
        {
            _id = Guid.NewGuid();
            _commandName = commandName;
            _commandSurname = commandSurname;
            _commandCountry = commandCountry;
            _commandCity = commandCity;
            _commandZipCode = commandZipCode;

        }

        public Reader(Guid commandId, string commandName, string commandSurname, string commandCountry, string commandCity, string commandZipCode)
        {
            _id = commandId;
            _commandName = commandName;
            _commandSurname = commandSurname;
            _commandCountry = commandCountry;
            _commandCity = commandCity;
            _commandZipCode = commandZipCode;
        }

        public Reader(Guid id, string commandName, string commandSurname, string commandCountry, string commandCity)
        {
            _id = id;
            _commandName = commandName;
            _commandSurname = commandSurname;
            _commandCountry = commandCountry;
            _commandCity = commandCity;
        }
        /*Do pytania czy nie zmienic*/
        public void Register(IReaderRepository readerRepository)
        {
            readerRepository.Save(new ReaderEntity(_id, _commandName, _commandSurname, _commandCountry, _commandCity));
        }

        public void Edit(IReaderRepository readerRepository)
        {
            readerRepository.Edit(new ReaderEntity(_id, _commandName, _commandSurname, _commandCountry, _commandCity));
        }

        public static void Delete(IReaderRepository readerRepository, Guid id)
        {
            readerRepository.Delete(id);
        }
    }
}