using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AtosLibrary.Application.Features.ReserveBook;
using AtosLibrary.Application.Features.ReserveBookNew;
using AtosLibrary.Application.Infrastructure;
using AtosLibrary.Presentation.Book;
using AtosLibrary.Presentation.BookReservation;
using AtosLibrary.Presentation.Reader;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AtosLibrary.WebHost.Pages
{
    public class ReserveBookModel : PageModel
    {
        private readonly IReaderPresentationRepository _readerPresentationRepository;
        private readonly IBookReservationPresentationRepository _bookReservationPresentationRepository;
        private readonly ICommandHandler<ReserveBookNewCommand> _commandHandler;

        public ReserveBookModel(IReaderPresentationRepository readerPresentationRepository, IBookReservationPresentationRepository bookReservationPresentationRepository, ICommandHandler<ReserveBookNewCommand> commandHandler)
        {
            _readerPresentationRepository = readerPresentationRepository;
            _commandHandler = commandHandler;
            _bookReservationPresentationRepository = bookReservationPresentationRepository;
        }

        public void OnGet(Guid id)
        {
            ReaderModel = _readerPresentationRepository.Get(id);
            Books = _bookReservationPresentationRepository.GetPossibleList().ToList();
        }

        [BindProperty]
        public string SearchText { get; set; }
        public ReaderModel ReaderModel { get; set; }

        public IList<BookReservationModel> Books { get; set; }
        public IActionResult OnPostReserve(Guid bookItemModelId, Guid readerModelId)
        {
            ReaderModel = _readerPresentationRepository.Get(readerModelId);
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                Books = _bookReservationPresentationRepository.GetPossibleList().ToList();
                return Page();
            }

            _commandHandler.Handle(new ReserveBookNewCommand(bookItemModelId, readerModelId));

            Books = _bookReservationPresentationRepository.GetPossibleList().ToList();
            return Page();
        }

        public IActionResult OnPostSearch(Guid id)
        {
            ReaderModel = _readerPresentationRepository.Get(id);
            Books = _bookReservationPresentationRepository.Search(SearchText).ToList();

            return Page();
        }
    }
}