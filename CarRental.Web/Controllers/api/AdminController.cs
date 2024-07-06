using CarRental.Domain.Domain;
using CarRental.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Web.Controllers.api
{
    namespace CarRental.Web.Controllers.API
    {
        [Route("api/[controller]")]
        [ApiController]
        public class AdminController : ControllerBase
        {
            private readonly ICarService _carService;
            public AdminController(ICarService carService)
            {
                _carService = carService;
            }



            [HttpGet("[action]")]
            public List<Car> GetAllCars()
            {
                return this._carService.GetCars();
            }
        }
    }
}
