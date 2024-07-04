using CarRental.Domain.Domain;
using CarRental.Domain.DTO;
using CarRental.Repository.Interface;
using CarRental.Service.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Service.Implementation
{
    public class WishlistService : IWishlistService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IRepository<Wishlist> _wishlistRepository;
        private readonly IRepository<Car> _carRepository;
        private readonly IRepository<Rental> _rentalRepository;
        private readonly IRepository<CarInRental> _carInRentalRepository;

        public WishlistService(ICustomerRepository customerRepository, IRepository<Wishlist> wishlistRepository, IRepository<Car> carRepository, IRepository<Rental> rentalRepository, IRepository<CarInRental> carInRentalRepository)
        {
            _customerRepository = customerRepository;
            _wishlistRepository = wishlistRepository;
            _carRepository = carRepository;
            _rentalRepository = rentalRepository;
            _carInRentalRepository = carInRentalRepository;
        }

        public Wishlist AddCarToWishlist(string customerId, AddToWishlistDTO model)
        {
            if (customerId != null)
            {
                var loggedInCustomer = _customerRepository.Get(customerId);

                var customerWishlist = loggedInCustomer?.Wishlist;

                var selectedCar = _carRepository.Get(model.SelectedCarId);

                if (selectedCar != null && customerWishlist != null)
                {
                    customerWishlist?.CarsInWishlist?.Add(new CarInWishlist
                    {
                        Car = selectedCar,
                        CarId = selectedCar.Id,
                        Wishlist = customerWishlist,
                        WishlistId = customerWishlist.Id,
                        Days = model.Days
                    });

                    return _wishlistRepository.Update(customerWishlist);
                }
            }
            return null;
        }

        public bool deleteFromWishlist(string customerId, Guid? Id)
        {
            if (customerId != null)
            {
                var loggedInUser = _customerRepository.Get(customerId);


                var carToDelete = loggedInUser?.Wishlist?.CarsInWishlist.First(z => z.CarId == Id);

                loggedInUser?.Wishlist?.CarsInWishlist?.Remove(carToDelete);

                _wishlistRepository.Update(loggedInUser.Wishlist);

                return true;

            }

            return false;
        }

        public AddToWishlistDTO getCarInfo(Guid Id)
        {
            var selectedCar = _carRepository.Get(Id);
            if (selectedCar != null)
            {
                var model = new AddToWishlistDTO
                {
                    SelectedCarModel = selectedCar.CarModel,
                    SelectedCarId = selectedCar.Id,
                    Days = 1
                };
                return model;
            }
            return null;
        }

        public WishlistDTO getWishlistDetails(string customerId)
        {
            if (customerId != null && !customerId.IsNullOrEmpty())
            {
                var loggedInCustomer = _customerRepository.Get(customerId);

                var allCars = loggedInCustomer?.Wishlist?.CarsInWishlist?.ToList();

                var totalPrice = 0.0;

                foreach (var item in allCars)
                {
                    totalPrice += Double.Round((item.Days * item.Car.Price), 2);
                }

                var model = new WishlistDTO
                {
                    AllCars = allCars,
                    TotalPrice = totalPrice
                };

                return model;

            }

            return new WishlistDTO
            {
                AllCars = new List<CarInWishlist>(),
                TotalPrice = 0.0
            };
        }

        public bool rentCars(string userId)
        {
            if (userId != null && !userId.IsNullOrEmpty())
            {
                var loggedInCustomer = _customerRepository.Get(userId);

                var customerWishlist = loggedInCustomer?.Wishlist;

                if (customerWishlist.CarsInWishlist.Count != 0)
                {

                    var customerRental = new Rental
                    {
                        Id = Guid.NewGuid(),
                        CustomerId = userId,
                        Customer = loggedInCustomer
                    };

                    _rentalRepository.Insert(customerRental);

                    var carsInRental = customerWishlist?.CarsInWishlist.Select(z => new CarInRental
                    {
                        Rental = customerRental,
                        RentalId = customerRental.Id,
                        CarId = z.CarId,
                        RentedCar = z.Car,
                        Days = z.Days
                    }).ToList();

                    _carInRentalRepository.InsertMany(carsInRental);

                    customerWishlist?.CarsInWishlist.Clear();

                    _wishlistRepository.Update(customerWishlist);

                    return true;
                }
            }
            return false;
        }
    }
}
