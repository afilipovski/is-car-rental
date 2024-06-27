using CarRental.Domain.Domain;
using CarRental.Repository.Interface;
using CarRental.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Service.Implementation
{
    public class RentalService : IRentalService
    {
        private readonly IRentalRepository _repository;

        public RentalService(IRentalRepository repository)
        {
            _repository = repository;
        }

        public List<Rental> GetRentals()
        {
            return _repository.GetAll().ToList();
        }
    }
}
