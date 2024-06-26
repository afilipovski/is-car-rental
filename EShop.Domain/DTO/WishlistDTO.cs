using CarRental.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Domain.DTO
{
    public class WishlistDTO
    {
        public List<CarInWishlist>? AllCars { get; set; }
        public double TotalPrice { get; set; }
    }
}
