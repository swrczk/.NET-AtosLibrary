using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AtosLibrary.WebHost
{
    using AtosLibrary.Application.Features.RegistrationBook;
    using AtosLibrary.Application.Infrastructure;
    using AtosLibrary.Presentation.Book;

    public class CreateBookModel : PageModel
    {
       
        private readonly ICommandHandler<RegistrationBookCommand> _commandHandler;

            public CreateBookModel(ICommandHandler<RegistrationBookCommand> commandHandler)
            {
                _commandHandler = commandHandler;
            }

            public IActionResult OnGet()
            {
                return Page();
            }

            [BindProperty]
            public BookModel BookModel { get; set; }

            public IActionResult OnPost()
            {
                if (!ModelState.IsValid)
                {
                    return Page();
                }

                _commandHandler.Handle(new RegistrationBookCommand(BookModel.Name, BookModel.Description, BookModel.Number));

                return RedirectToPage("/BookIndex");
            }
        }
    }
