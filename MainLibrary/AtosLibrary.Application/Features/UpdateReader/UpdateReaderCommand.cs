using System;

namespace AtosLibrary.Application.Features.UpdateReader
{
    public class UpdateReaderCommand 
    {
        public UpdateReaderCommand(Guid readerModelId, string readerModelName, string readerModelSurname, string readerModelCountry, string readerModelCity)
        {
            Id = readerModelId;
            ReaderModelName = readerModelName;
            ReaderModelSurname = readerModelSurname;
            ReaderModelCountry = readerModelCountry;
            ReaderModelCity = readerModelCity;
        }

        public string ReaderModelName { get; set; }

        public string ReaderModelSurname { get; set; }

        public string ReaderModelCity { get; set; }

        public string ReaderModelCountry { get; set; }

        public Guid Id { get; set; }
        public string ReaderModelZipCode { get; set; }
    }
}