using System.ComponentModel.DataAnnotations;
using AtosLibrary.Application.Features.RegistrationBook;
using AtosLibrary.Application.Infrastructure;
using AtosLibrary.Domain.Book;
using AtosLibrary.Presentation.Book;

namespace AtosLibrary.Application.Features.DeleteBook
{

    public class DeleteBookCommandHandler : ICommandHandler<DeleteBookCommand>
    {
        private readonly IBookRepository _bookRepository;

        private IBookFactory _bookFactory;

        public DeleteBookCommandHandler( IBookRepository bookRepository, IBookFactory bookFactory)
        {
            _bookRepository = bookRepository;
            _bookFactory = bookFactory;
        }


        public void Handle(DeleteBookCommand command)
        {
            Book.Delete(_bookRepository, command.Id);
            //TO DO
        }
    }
}