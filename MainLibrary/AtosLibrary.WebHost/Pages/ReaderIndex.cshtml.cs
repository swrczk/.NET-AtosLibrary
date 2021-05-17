
using System;
using System.Collections.Generic;
using System.Linq;
using AtosLibrary.Presentation.Reader;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AtosLibrary.WebHost
{
    using AtosLibrary.Application.Features.DeleteReader;
    using AtosLibrary.Application.Infrastructure;

    public class ReaderIndexModel : PageModel
    {
        private readonly IReaderPresentationRepository _presentationRepository;

        private ICommandHandler<DeleteReaderCommand> _commandHandler;


        public ReaderIndexModel(IReaderPresentationRepository presentationRepository, ICommandHandler<DeleteReaderCommand> commandHandler)
        {
            _presentationRepository = presentationRepository;
            _commandHandler = commandHandler;
        }
        [BindProperty]
        public ReaderModel readerModel { get; set; }

        public IList<ReaderModel> Readers { get; set; }

        [BindProperty]
        public string SearchText { get; set; }

        public void OnGet()
        {
            Readers = _presentationRepository.GetList().ToList();
        }

        public IActionResult OnPostSearch()
        {
            Readers = _presentationRepository.Search(SearchText).ToList();

            return Page();
        }

        [BindProperty]
        public Guid Id { get; set; }
        public IActionResult OnPostDelete(Guid id)
        {
            readerModel = _presentationRepository.Get(id);
            _commandHandler.Handle(new DeleteReaderCommand(readerModel.Id));
            Readers = _presentationRepository.GetList().ToList();
            return Page();
            //      Readers = _presentationRepository;
        }
    }
}