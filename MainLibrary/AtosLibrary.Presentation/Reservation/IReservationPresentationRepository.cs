using System;
using System.Collections.Generic;
using System.Text;

namespace AtosLibrary.Presentation.Reservation
{
    public interface IReservationPresentationRepository
    {
        ReservationModel Get(Guid id);

        IEnumerable<ReservationModel> GetList();

        IEnumerable<ReservationModel> GetSearchList(string searchText);

        IEnumerable<ReservationModel> Search(string searchText);

    }
}
