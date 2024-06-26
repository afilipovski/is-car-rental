using CarRental.Domain.Identity;
using CarRental.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Repository.Implementation
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<CarRentalCustomer> entities;
        string errorMessage = string.Empty;

        public CustomerRepository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<CarRentalCustomer>();
        }
        public IEnumerable<CarRentalCustomer> GetAll()
        {
            return entities.AsEnumerable();
        }

        public CarRentalCustomer Get(string id)
        {
            var strGuid = id.ToString();
            return entities
                .Include(z => z.Wishlist)
                .Include(z => z.Wishlist.CarsInWishlist)
                .ThenInclude(ciw => ciw.Car)
                .First(s => s.Id == strGuid);
        }
        public void Insert(CarRentalCustomer entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            context.SaveChanges();
        }

        public void Update(CarRentalCustomer entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Update(entity);
            context.SaveChanges();
        }

        public void Delete(CarRentalCustomer entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
        }
    }
}
