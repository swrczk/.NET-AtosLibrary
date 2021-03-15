using System;
using System.Collections.Generic;
using System.Linq;
using AtosLibrary.Infrastructure.Entities;

namespace AtosLibrary.Infrastructure.InMemory
{
    public class InMemoryReservation : IInMemoryDb<ReservationEntity>
    {
        private readonly List<ReservationEntity> _reservationEntities;

        public InMemoryReservation()
        {
            _reservationEntities = new List<ReservationEntity>();
        }
        public ReservationEntity Get(Guid id)
        {
            return _reservationEntities.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<ReservationEntity> GetAll()
        {
            return _reservationEntities;
        }

        public void Add(ReservationEntity entity)
        {
            _reservationEntities.Add(entity);
        }

        public void Delete(Guid id)
        {
            var reservation = Get(id);
            _reservationEntities.Remove(reservation);
        }

        public void Edit(ReservationEntity entity)
        {
            var reservation = Get(entity.Id);
            reservation.BookItemId = entity.BookItemId;
            reservation.ReaderId = entity.ReaderId;
            reservation.DateBeginOfReservation = entity.DateBeginOfReservation;
            reservation.DateEndOfReservation = entity.DateEndOfReservation;
            reservation.Status = entity.Status;
        }
    }
}
