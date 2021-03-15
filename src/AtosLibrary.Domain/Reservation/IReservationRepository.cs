using System;
using System.Collections.Generic;
using AtosLibrary.Infrastructure;
using AtosLibrary.Infrastructure.Entities;

//Dlaczego łączymy się z infrastruktura
namespace AtosLibrary.Domain.Reservation
{
    public interface IReservationRepository
    {
        void Save(ReservationEntity reservationEntity);
        void Edit(ReservationEntity reservationEntity);
        ReservationEntity Get(Guid id);

        IEnumerable<ReservationEntity> GetList();
    }
}
