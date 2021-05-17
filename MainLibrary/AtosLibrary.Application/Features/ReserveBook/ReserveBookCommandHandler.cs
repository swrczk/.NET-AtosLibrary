using AtosLibrary.Application.Features.DeleteReader;
using AtosLibrary.Application.Infrastructure;
using AtosLibrary.Domain.Book;

namespace AtosLibrary.Application.Features.ReserveBook
{
    public class ReserveBookCommandHandler : ICommandHandler<ReserveBookCommand>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IBookFactory _bookFactory;

        public ReserveBookCommandHandler(IBookRepository bookRepository, IBookFactory bookFactory)
        {
            _bookRepository = bookRepository;
            _bookFactory = bookFactory;
        }

        public void Handle(ReserveBookCommand command)
        {
            var book = _bookFactory.Create(command.BookId, _bookRepository);
            book.Reserve(command.ReaderId, _bookRepository);
        }
    }
}