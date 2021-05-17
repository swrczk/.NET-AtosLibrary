using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AtosLibrary.Infrastructure.Entities;
using AtosLibrary.Infrastructure.SQLDataBase;

namespace AtosLibrary.Domain.Reservation
{
    public class ReservationRepositoryDB : IReservationRepository
    {
        private readonly AtosLibraryContext _context;

        public ReservationRepositoryDB(AtosLibraryContext context)
        {
            _context = context;
        }


        public void Save(ReservationEntity reservationEntity)
        {
            this._context.Reservation.Add(reservationEntity);
            this._context.SaveChanges();
        }

        public void Edit(ReservationEntity reservationEntity)
        {
            var reservationToEdit = Get(reservationEntity.Id);
            reservationToEdit.BookItemId = reservationEntity.BookItemId;
            reservationToEdit.ReaderId = reservationEntity.ReaderId;
            reservationToEdit.DateBeginOfReservation = reservationEntity.DateBeginOfReservation;
            reservationToEdit.DateEndOfReservation = reservationEntity.DateEndOfReservation;
            reservationToEdit.Status = reservationEntity.Status;

            this._context.SaveChanges();
        }

        public ReservationEntity Get(Guid id)
        {
            return this._context.Reservation.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<ReservationEntity> GetList()
        {
            return this._context.Reservation.ToList();
        }
    }
}
