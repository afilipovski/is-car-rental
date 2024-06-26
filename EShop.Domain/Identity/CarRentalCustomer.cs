using CarRental.Domain.Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Domain.Identity
{
    public class CarRentalCustomer : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public Wishlist? Wishlist { get; set; }
        public virtual ICollection<Car>? MyCars { get; set; }
    }
}
