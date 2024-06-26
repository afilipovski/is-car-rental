using CarRental.Domain.Identity;
using System.ComponentModel.DataAnnotations;

namespace CarRental.Domain.Domain
{
    public class Rental : BaseEntity
    {
        public string? CustomerId { get; set; }
        public CarRentalCustomer? Customer { get; set; }

        public ICollection<CarInRental>? CarsInRental { get; set; }
    }
}
