using System;
using AtosLibrary.Application.Features.EditReader;
using AtosLibrary.Application.Infrastructure;
using AtosLibrary.Presentation.Reader;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AtosLibrary.WebHost
{
    public class EditReaderModel : PageModel
    {
        private readonly IReaderPresentationRepository _presentationRepository;
        private readonly ICommandHandler<EditReaderCommand> _commandHandler;

        public EditReaderModel(IReaderPresentationRepository presentationRepository, ICommandHandler<EditReaderCommand> commandHandler)
        {
            _presentationRepository = presentationRepository;
            _commandHandler = commandHandler;
        }

        public void OnGet(Guid id)
        {
            ReaderModel = _presentationRepository.Get(id);
        }
        [BindProperty]
        public ReaderModel ReaderModel { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _commandHandler.Handle(new EditReaderCommand(ReaderModel.Id, ReaderModel.Name, ReaderModel.Surname, ReaderModel.Country, ReaderModel.City, ReaderModel.ZipCode));

            return RedirectToPage("/ReaderIndex");
        }
    }
}