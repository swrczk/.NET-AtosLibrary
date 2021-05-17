using AtosLibrary.Application.Features.DeleteReader;
using AtosLibrary.Application.Infrastructure;
using AtosLibrary.Presentation.Reader;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AtosLibrary.WebHost
{
    public class DeleteReaderModel : PageModel
    {
        private readonly ICommandHandler<DeleteReaderCommand> _commandHandler;

        public DeleteReaderModel(ICommandHandler<DeleteReaderCommand> commandHandler)
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

            _commandHandler.Handle(command: new DeleteReaderCommand(ReaderModel.Id));

            return RedirectToPage("/ReaderIndex");
        }

    }
}