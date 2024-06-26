using CarRental.Domain.Identity;
using System.ComponentModel.DataAnnotations;

namespace CarRental.Domain.Domain
{
    public class Car : BaseEntity
    {
        [Required]
        public string? CarModel { get; set; }
        [Required]
        public string? CarManufacturer { get; set; }
        [Required]
        public string? CarImage { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public double Rating { get; set; }
        public virtual CarRentalCustomer? CreatedBy { get; set; }
        public virtual ICollection<CarInWishlist>? CarsInWishlist { get; set; }
        public ICollection<CarInRental>? CarsInRental { get; set; }
    }
}
