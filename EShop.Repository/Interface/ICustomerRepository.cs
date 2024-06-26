using CarRental.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Repository.Interface
{
    public interface ICustomerRepository
    {
        IEnumerable<CarRentalCustomer> GetAll();
        CarRentalCustomer Get(string id);
        void Insert(CarRentalCustomer entity);
        void Update(CarRentalCustomer entity);
        void Delete(CarRentalCustomer entity);
    }
}
