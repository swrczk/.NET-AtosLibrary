using AtosLibrary.Application.Features.DeleteReader;
using AtosLibrary.Application.Infrastructure;
using AtosLibrary.Domain.Reader;

namespace AtosLibrary.Application.Features.RegistrationReader
{
    public class RegistrationReaderCommandHandler : ICommandHandler<RegistrationReaderCommand>
    {
        private readonly IReaderFactory _readerFactory;
        private readonly IReaderRepository _readerRepository;


        public RegistrationReaderCommandHandler(IReaderFactory readerFactory, IReaderRepository readerRepository)
        {
            _readerFactory = readerFactory;
            _readerRepository = readerRepository;
        }

        public void Handle(RegistrationReaderCommand command)
        {
            var reader = _readerFactory.Create(command.Name, command.Surname, command.Country, command.City, command.ZipCode);
            reader.Register(_readerRepository);
        }
    }
}