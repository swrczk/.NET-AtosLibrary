using System.ComponentModel.DataAnnotations;
using AtosLibrary.Application.Features.RegistrationReader;
using AtosLibrary.Application.Infrastructure;
using AtosLibrary.Domain.Reader;
using AtosLibrary.Presentation.Reader;

namespace AtosLibrary.Application.Features.UpdateReader
{
    public class UpdateReaderCommandHandler : ICommandHandler<UpdateReaderCommand>
    {
        private readonly IReaderRepository _readerRepository;

        private IReaderFactory _readerFactory;

        public UpdateReaderCommandHandler( IReaderRepository readerRepository, IReaderFactory readerFactory)
        {
            _readerRepository = readerRepository;
            _readerFactory = readerFactory;
        }


        public void Handle(UpdateReaderCommand command)
        {
            var reader = _readerFactory.Create(command.Id, command.ReaderModelName, command.ReaderModelSurname, command.ReaderModelCountry, command.ReaderModelCity, command.ReaderModelZipCode);
            reader.Edit(_readerRepository);
            //TO DO
        }
    }
}