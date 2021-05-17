using System;
using System.Collections.Generic;
using System.Text;

namespace AtosLibrary.Presentation.BookReservation
{
    public class BookReservationModel
    {
        public Guid BookId { get; set; }
        public string BookName { get; set; }
        public int NumberOfAvailableBooks { get; set; }
        public Guid BookItemId { get; set; }
    }
}
