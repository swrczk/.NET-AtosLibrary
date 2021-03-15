using AtosLibrary.Application.Infrastructure;
using AtosLibrary.Domain.Book;
using AtosLibrary.Domain.Reader;
using AtosLibrary.Domain.Reservation;

namespace AtosLibrary.Application.Features.ReserveBookNew
{
    public class ReserveBookNewCommandHandler : ICommandHandler<ReserveBookNewCommand>
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IReservationFactory _reservationFactory;

        public ReserveBookNewCommandHandler(IReservationRepository reservationRepository, IReservationFactory reservationFactory)
        {
            _reservationRepository = reservationRepository;
            _reservationFactory = reservationFactory;
        }

        public void Handle(ReserveBookNewCommand command)
        {
            var reservation = _reservationFactory.Create(command.BookItemId, command.ReaderId);
            reservation.Reserve(_reservationRepository);
        }
    }
}