using CarRental.Domain.Domain;
using CarRental.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Repository.Implementation
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly ApplicationDbContext _context;

        public RestaurantRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Restaurants> getAllRestaurants()
        {
            _context.SwitchToPartherDb(true);
            var restaurants = _context.Restaurants.ToList();
            _context.SwitchToPartherDb(false);
            return restaurants;

        }
    }
}
