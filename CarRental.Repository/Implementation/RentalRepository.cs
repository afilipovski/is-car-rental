using CarRental.Domain.Domain;
using CarRental.Domain.Identity;
using CarRental.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Repository.Implementation
{
    public class RentalRepository : IRentalRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<Rental> entities;

        public RentalRepository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<Rental>();
        }

        public IEnumerable<Rental> GetAll()
        {
            return entities
                .Include(r => r.Customer)
                .Include(r => r.CarsInRental)
                .ThenInclude(cir => cir.RentedCar)
                .AsEnumerable();
        }
    }
}
