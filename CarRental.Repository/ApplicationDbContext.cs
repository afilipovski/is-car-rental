using CarRental.Domain.Domain;
using CarRental.Domain.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CarRental.Repository
{
    public class ApplicationDbContext : IdentityDbContext<CarRentalCustomer>
    {
        private readonly IConfiguration _configuration;
        private bool _usePartnerDatabase;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration, bool usePartnerDatabase = false)
            : base(options)
        {
            _configuration = configuration;
            _usePartnerDatabase = usePartnerDatabase;
        }

        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Wishlist> Wishlists { get; set; }
        public virtual DbSet<Rental> Rentals { get; set; }
        public virtual DbSet<CarInWishlist> CarsInWishlists { get; set; }
        public virtual DbSet<CarInRental> CarsInRentals { get; set; }
        public virtual DbSet<Restaurants> Restaurants { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
            {
                //this._usePartnerDatabase = true;
                var connectionString = _usePartnerDatabase
                    ? _configuration.GetConnectionString("PartnerDatabase")
                    : _configuration.GetConnectionString("DefaultConnection");

                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        public void SwitchToPartherDb(bool setToPartherDb)
        {
            this._usePartnerDatabase = setToPartherDb;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
