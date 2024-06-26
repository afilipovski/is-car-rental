
using CarRental.Domain.Domain;
using CarRental.Domain.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Repository
{
    public class ApplicationDbContext : IdentityDbContext<CarRentalCustomer>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Wishlist> Wishlists { get; set; }
        public virtual DbSet<Rental> Rentals { get; set; }
        public virtual DbSet<CarInWishlist> CarsInWishlists { get; set; }
        public virtual DbSet<CarInRental> CarsInRentals { get; set; }
    }
}
