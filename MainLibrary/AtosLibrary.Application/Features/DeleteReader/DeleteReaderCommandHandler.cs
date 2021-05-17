using AtosLibrary.Application.Infrastructure;
using AtosLibrary.Domain.Reader;

namespace AtosLibrary.Application.Features.DeleteReader
{

    public class DeleteReaderCommandHandler : ICommandHandler<DeleteReaderCommand>
    {
        private readonly IReaderRepository _readerRepository;

        private readonly IReaderFactory _readerFactory;

        public DeleteReaderCommandHandler( IReaderRepository readerRepository, IReaderFactory readerFactory)
        {
            _readerRepository = readerRepository;
            _readerFactory = readerFactory;
        }


        public void Handle(DeleteReaderCommand command)
        {
            Reader.Delete(_readerRepository, command.Id);
            //TO DO
        }
    }
}