using System.ComponentModel.DataAnnotations;

namespace AtosLibrary.Infrastructure.Entities
{
    public enum EnumStatusReservation
    {
        [Display(Name = "Reserved book")] 
        Reserved = 1,
        Rented = 2,
        Returned = 3
    }
}