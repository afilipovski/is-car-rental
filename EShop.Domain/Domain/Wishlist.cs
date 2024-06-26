using CarRental.Domain.Identity;
using System.ComponentModel.DataAnnotations;


namespace CarRental.Domain.Domain
{
    public class Wishlist : BaseEntity
    {
        public string? CustomerId { get; set; }
        public CarRentalCustomer? Customer { get; set; }
        public virtual ICollection<CarInWishlist>? CarsInWishlist { get; set; }
    }
}
