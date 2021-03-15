using System;
using System.Collections.Generic;
using System.Text;
using AtosLibrary.Infrastructure;
using AtosLibrary.Infrastructure.Entities;
using AtosLibrary.Infrastructure.InMemory;

namespace AtosLibrary.Domain.Reservation
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly IInMemoryDb<ReservationEntity> _inMemory;

        public ReservationRepository(IInMemoryDb<ReservationEntity> inMemory)
        {
            _inMemory = inMemory;
        }

        public void Save(ReservationEntity reservationEntity)
        {
            _inMemory.Add(reservationEntity);
        }

        public void Edit(ReservationEntity reservationEntity)
        {
            _inMemory.Edit(reservationEntity);
        }

        public ReservationEntity Get(Guid id)
        {
            return _inMemory.Get(id);
        }

        public IEnumerable<ReservationEntity> GetList()
        {
            return _inMemory.GetAll();
        }
    }
}
