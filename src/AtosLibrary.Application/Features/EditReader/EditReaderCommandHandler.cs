using AtosLibrary.Application.Features.DeleteReader;
using AtosLibrary.Application.Features.EditReader;
using AtosLibrary.Application.Infrastructure;
using AtosLibrary.Domain.Reader;

namespace AtosLibrary.Application.Features.EditReader
{
    public class EditReaderCommandHandler : ICommandHandler<EditReaderCommand>
    {
        private readonly IReaderFactory _readerFactory;
        private readonly IReaderRepository _readerRepository;


        public EditReaderCommandHandler(IReaderFactory readerFactory, IReaderRepository readerRepository)
        {
            _readerFactory = readerFactory;
            _readerRepository = readerRepository;
        }

        public void Handle(EditReaderCommand command)
        {
            Reader reader = _readerFactory.Create(command.Id,command.Name, command.Surname, command.Country, command.City, command.ZipCode);
            reader.Edit(_readerRepository);
        }

    }
}