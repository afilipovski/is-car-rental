using System.ComponentModel.DataAnnotations;


namespace CarRental.Domain.Domain
{
    public class CarInWishlist : BaseEntity
    {
        public Guid CarId { get; set; }
        public Car? Car { get; set; }
        public Guid WishlistId { get; set; }
        public Wishlist? Wishlist { get; set; }
        public int Days { get; set; }
    }
}
