using CarRental.Domain.Domain;
using CarRental.Repository.Interface;
using CarRental.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Service.Implementation
{
    public class ProductService : ICarService
    {
        private readonly IRepository<Car> _carRepository;
        private readonly ICustomerRepository _customerRepository;

        public ProductService(IRepository<Car> carRepository, ICustomerRepository customerRepository)
        {
            _carRepository = carRepository;
            _customerRepository = customerRepository;
        }


        public Car CreateNewCar(string customerId, Car car)
        {
            var createdBy = _customerRepository.Get(customerId);
            car.CreatedBy = createdBy;
            return _carRepository.Insert(car);
        }

        public Car DeleteCar(Guid id)
        {
            var product_to_delete = this.GetCarById(id);
            return _carRepository.Delete(product_to_delete);
        }

        public Car GetCarById(Guid? id)
        {
            return _carRepository.Get(id);
        }

        public List<Car> GetCars()
        {
            return _carRepository.GetAll().ToList();
        }

        public Car UpdateCar(Car car)
        {
           return _carRepository.Update(car);
        }
    }
}
