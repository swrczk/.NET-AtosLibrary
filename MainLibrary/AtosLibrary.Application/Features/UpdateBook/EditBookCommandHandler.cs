using System.ComponentModel.DataAnnotations;
using AtosLibrary.Application.Features.RegistrationBook;
using AtosLibrary.Application.Infrastructure;
using AtosLibrary.Domain.Book;
using AtosLibrary.Presentation.Book;

namespace AtosLibrary.Application.Features.UpdateBook
{
    public class EditBookCommandHandler : ICommandHandler<EditBookCommand>
    {
        private readonly IBookRepository _bookRepository;

        private IBookFactory _bookFactory;

        public EditBookCommandHandler(IBookRepository bookRepository, IBookFactory bookFactory)
        {
            _bookRepository = bookRepository;
            _bookFactory = bookFactory;
        }


        public void Handle(EditBookCommand command)
        {
            var book = _bookFactory.Create(command.Id, command.BookModelName, command.BookModelDescription, command.BookModelNumber);
            book.Edit(_bookRepository);
        }
    }
}