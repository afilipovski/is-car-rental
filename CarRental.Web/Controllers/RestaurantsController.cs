using CarRental.Domain.Domain;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Web.Controllers
{
    public class RestaurantsController : Controller
    {
        public IActionResult Index()
        {
            HttpClient client = new HttpClient();
            string URL = "https://integriraniproject.azurewebsites.net/api/Admin/GetAllRestaurants";

            HttpResponseMessage response = client.GetAsync(URL).Result;
            var data = response.Content.ReadAsAsync<List<Restaurants>>().Result;
            return View(data);
        }
    }
}