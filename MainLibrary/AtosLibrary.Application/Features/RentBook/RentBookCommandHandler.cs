using AtosLibrary.Application.Infrastructure;
using AtosLibrary.Domain.Reservation;

namespace AtosLibrary.Application.Features.RentBook
{
    public class RentBookCommandHandler : ICommandHandler<RentBookCommand>
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IReservationFactory _reservationFactory;

        public RentBookCommandHandler(IReservationRepository reservationRepository, IReservationFactory reservationFactory)
        {
            _reservationRepository = reservationRepository;
            _reservationFactory = reservationFactory;
        }

        public void Handle(RentBookCommand command)
        {
            var reservation = _reservationFactory.Create(command.BookItemId, command.ReaderId,command.ReservationId);
            reservation.Rent(_reservationRepository);
        }
    }
}