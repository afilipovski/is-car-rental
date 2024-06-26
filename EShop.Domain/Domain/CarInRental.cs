using System.ComponentModel.DataAnnotations;


namespace CarRental.Domain.Domain
{
    public class CarInRental : BaseEntity
    {
        public Guid CarId { get; set; }
        public Car? RentedCar { get; set; }

        public Guid RentalId { get; set; }
        public Rental? Rental { get; set; }
        public int Days { get; set; }
    }
}
