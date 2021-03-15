using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AtosLibrary.WebHost
{
    using AtosLibrary.Application.Features.DeleteBook;
    using AtosLibrary.Application.Infrastructure;
    using AtosLibrary.Presentation.Book;

    public class BookIndexModel : PageModel
    {


        private readonly IBookPresentationRepository _presentationRepository;

        private ICommandHandler<DeleteBookCommand> _commandHandler;


        public BookIndexModel(
            IBookPresentationRepository presentationRepository,
            ICommandHandler<DeleteBookCommand> commandHandler)
        {
            _presentationRepository = presentationRepository;
            _commandHandler = commandHandler;
        }

        [BindProperty]
        public BookModel bookModel { get; set; }

        public IList<BookModel> Books { get; set; }

        [BindProperty]
        public string SearchText { get; set; }

        public void OnGet()
        {
            Books = _presentationRepository.GetList().ToList();
        }

        public IActionResult OnPost()
        {
            Books = _presentationRepository.Search(SearchText).ToList();

            return Page();
        }

        [BindProperty]
        public Guid Id { get; set; }

        public IActionResult OnPostDelete(Guid id)
        {
            bookModel = _presentationRepository.Get(id);
            _commandHandler.Handle(
                new DeleteBookCommand(bookModel.Id));
            Books = _presentationRepository.GetList().ToList();
            return Page();
        }
    }
}
