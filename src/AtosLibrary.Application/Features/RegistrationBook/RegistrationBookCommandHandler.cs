using AtosLibrary.Application.Features.DeleteReader;
using AtosLibrary.Application.Infrastructure;
using AtosLibrary.Domain.Book;
using AtosLibrary.Domain.BookItem;

namespace AtosLibrary.Application.Features.RegistrationBook
{
    public class RegistrationBookCommandHandler : ICommandHandler<RegistrationBookCommand>
    {
        private readonly IBookFactory _bookFactory;
        private readonly IBookRepository _bookRepository;
        private readonly IBookItemFactory _bookItemFactory;
        private readonly IBookItemRepository _bookItemRepository;

        public RegistrationBookCommandHandler(IBookFactory bookFactory, IBookRepository bookRepository, IBookItemFactory bookItemFactory, IBookItemRepository bookItemRepository)
        {
            _bookFactory = bookFactory;
            _bookRepository = bookRepository;
            _bookItemFactory = bookItemFactory;
            _bookItemRepository = bookItemRepository;
        }

        public void Handle(RegistrationBookCommand command)
        {
            var book = _bookFactory.Create(command.Name, command.Description, command.Number);
            book.Register(_bookRepository);
            for (int i = 0; i < command.Number; i++)
            {
                var bookItem = _bookItemFactory.Create(book.GetId());
                _bookItemRepository.Save(bookItem.MakeEntity());
            }
        }
    }
}