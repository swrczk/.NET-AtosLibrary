using AtosLibrary.Application.Features.RegistrationReader;
using AtosLibrary.Application.Infrastructure;
using AtosLibrary.Presentation.Reader;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AtosLibrary.WebHost
{
    public class CreateReaderModel : PageModel
    {
        private readonly ICommandHandler<RegistrationReaderCommand> _commandHandler;

        public CreateReaderModel(ICommandHandler<RegistrationReaderCommand> commandHandler)
        {
            _commandHandler = commandHandler;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ReaderModel ReaderModel { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _commandHandler.Handle(new RegistrationReaderCommand(ReaderModel.Name, ReaderModel.Surname, ReaderModel.Country, ReaderModel.City, ReaderModel.ZipCode));

            return RedirectToPage("/ReaderIndex");
        }
    }
}