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
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository repository;

        public RestaurantService(IRestaurantRepository repository)
        {
            this.repository = repository;
        }

        public List<Restaurants> GetAllRestaurants()
        {
            return repository.getAllRestaurants();
        }
    }
}
