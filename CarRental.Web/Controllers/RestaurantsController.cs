using CarRental.Domain.Domain;
using CarRental.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Web.Controllers
{
    public class RestaurantsController : Controller
    {
        private readonly IRestaurantService _restaurantService;

        public RestaurantsController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        /*public IActionResult Index()
{
   HttpClient client = new HttpClient();
   string URL = "https://integriraniproject.azurewebsites.net/api/Admin/GetAllRestaurants";

   HttpResponseMessage response = client.GetAsync(URL).Result;
   var data = response.Content.ReadAsAsync<List<Restaurants>>().Result;
   return View(data);
}*/
        public IActionResult Index()
        {
            var data = _restaurantService.GetAllRestaurants();
            return View(data);
        }
    }
}