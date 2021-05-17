using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AtosLibrary.Application.Features.RentBook;
using AtosLibrary.Application.Features.ReserveBookNew;
using AtosLibrary.Application.Features.ReturnBook;
using AtosLibrary.Application.Infrastructure;
using AtosLibrary.Presentation.Reservation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AtosLibrary.WebHost.Pages
{
    public class ReservationIndexModel : PageModel
    {
        private readonly IReservationPresentationRepository _reservationPresentationRepository;

        private ICommandHandler<RentBookCommand> _rentCommandHandler;
        private ICommandHandler<ReturnBookCommand> _returnCommandHandler;

        public ReservationIndexModel(IReservationPresentationRepository reservationPresentationRepository,
            ICommandHandler<RentBookCommand> rentCommandHandler, ICommandHandler<ReturnBookCommand> returnCommandHandler)
        {
            _reservationPresentationRepository = reservationPresentationRepository;
            _rentCommandHandler = rentCommandHandler;
            _returnCommandHandler = returnCommandHandler;
        }

        [BindProperty]
        public string SearchText { get; set; }
        [BindProperty]
        public ReservationModel ReservationModel { get; set; }
        [BindProperty]
        public string datebeginofreservation { get; set; }

        public IList<ReservationModel> Reservations { get; set; }
        public void OnGet()
        {
            Reservations = _reservationPresentationRepository.GetList().ToList();
        }

        public IActionResult OnPostSearch()
        {
            Reservations = _reservationPresentationRepository.Search(SearchText).ToList();
            return Page();
        }

        public IActionResult OnPostRent(Guid reservationid, Guid readerid, Guid bookItemId)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _rentCommandHandler.Handle(new RentBookCommand(bookItemId, readerid, reservationid));

            Reservations = _reservationPresentationRepository.GetList().ToList();
            return Page();
        }

        public IActionResult OnPostReturn(Guid reservationid)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                Reservations = _reservationPresentationRepository.GetList().ToList();
                return Page();
            }

            _returnCommandHandler.Handle(new ReturnBookCommand(reservationid));

            Reservations = _reservationPresentationRepository.GetList().ToList();
            return Page();
        }
    }
}