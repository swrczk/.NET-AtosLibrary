using AtosLibrary.Application.Infrastructure;
using AtosLibrary.Domain.Reservation;

namespace AtosLibrary.Application.Features.ReturnBook
{
    public class ReturnBookCommandHandler : ICommandHandler<ReturnBookCommand>
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IReservationFactory _reservationFactory;

        public ReturnBookCommandHandler(IReservationRepository reservationRepository, IReservationFactory reservationFactory)
        {
            _reservationRepository = reservationRepository;
            _reservationFactory = reservationFactory;
        }

        public void Handle(ReturnBookCommand command)
        {
            var reservation = _reservationFactory.Clone(_reservationRepository, command.ReservationId);
            reservation.Return(_reservationRepository);
        }
    }
}