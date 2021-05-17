using System;
using System.Collections.Generic;
using System.Linq;
using AtosLibrary.Application.Features.DeleteBookItem;
using AtosLibrary.Application.Features.RegistrationBook;
using AtosLibrary.Application.Features.RegistrationBookItem;
using AtosLibrary.Application.Features.UpdateBook;
using AtosLibrary.Application.Infrastructure;
using AtosLibrary.Infrastructure.Entities;
using AtosLibrary.Presentation.Book;
using AtosLibrary.Presentation.BookItem;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AtosLibrary.WebHost
{
    public class EditBookModel : PageModel
    {
            private readonly IBookPresentationRepository _presentationRepository;
            private readonly IBookItemPresentationRepository _bookItemPresentationRepository;
            private readonly ICommandHandler<EditBookCommand> _commandHandler;
            private readonly ICommandHandler<RegistrationBookItemCommand> _registrationBookItemCommandHandler;
            private readonly ICommandHandler<DeleteBookItemCommand> _deleteBookItemCommandHandler;

            public EditBookModel(IBookPresentationRepository presentationRepository, ICommandHandler<EditBookCommand> commandHandler, IBookItemPresentationRepository bookItemPresentationRepository, ICommandHandler<RegistrationBookItemCommand> registrationBookItemCommandHandler, ICommandHandler<DeleteBookItemCommand> deleteBookItemCommandHandler)
            {
                _presentationRepository = presentationRepository;
                _commandHandler = commandHandler;
                _bookItemPresentationRepository = bookItemPresentationRepository;
                _registrationBookItemCommandHandler = registrationBookItemCommandHandler;
                _deleteBookItemCommandHandler = deleteBookItemCommandHandler;
            }

            public void OnGet(Guid id)
            {
                BookModel = _presentationRepository.Get(id);
                BookItemModels = _bookItemPresentationRepository.GetListByBookId(id).ToList();
            }
            [BindProperty]
            public BookModel BookModel { get; set; }
            public IList<BookItemModel> BookItemModels { get; set; }

            public IActionResult OnPost()
            {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _commandHandler.Handle(new EditBookCommand(BookModel.Id, BookModel.Name, BookModel.Description, BookModel.Number));

            return RedirectToPage("/BookIndex");
            }

            public IActionResult OnPostCreateNewBookItem(Guid id)
            {
                _registrationBookItemCommandHandler.Handle(new RegistrationBookItemCommand(id));
                BookModel = _presentationRepository.Get(id);
                BookItemModels = _bookItemPresentationRepository.GetListByBookId(id).ToList();
            return Page();
            }

            public IActionResult OnPostDelete(Guid bookid, Guid itemid)
            {
                _deleteBookItemCommandHandler.Handle(new DeleteBookItemCommand(itemid));
                BookModel = _presentationRepository.Get(bookid);
                BookItemModels = _bookItemPresentationRepository.GetListByBookId(bookid).ToList();
                return Page();
        }
    }
}
