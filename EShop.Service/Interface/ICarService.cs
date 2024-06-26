using CarRental.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Service.Interface
{
    public interface ICarService
    {
        public List<Car> GetCars();
        public Car GetCarById(Guid? id);
        public Car CreateNewCar(string customerId, Car car);
        public Car UpdateCar(Car car);
        public Car DeleteCar(Guid id);
    }
}
