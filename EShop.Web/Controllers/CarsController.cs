using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarRental.Repository;
using CarRental.Domain.Domain;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using CarRental.Domain.DTO;
using CarRental.Service.Interface;

namespace CarRental.Web.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICarService _carService;
        private readonly IWishlistService _wishlistService;

        public CarsController(ICarService carService, IWishlistService wishlistService)
        {
            _carService = carService;
            _wishlistService = wishlistService;
        }

        // GET: Cars
        public IActionResult Index()
        {
            return View(_carService.GetCars());
        }

        // GET: Cars/Details/5
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = _carService.GetCarById(id);

            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // GET: Cars/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult Create([Bind("Id,CarModel,CarManufacturer,CarImage,Price,Rating")] Car car)
        {
            if (ModelState.IsValid)
            {
                var loggedInUser = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "";
                _carService.CreateNewCar(loggedInUser, car);
                return RedirectToAction(nameof(Index));
            }
            return View(car);
        }

        // GET: Cars/Edit/5
        [Authorize]
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = _carService.GetCarById(id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit(Guid id, [Bind("Id,CarModel,CarManufacturer,CarImage,Price,Rating")] Car car)
        {
            if (id != car.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _carService.UpdateCar(car);
                return RedirectToAction(nameof(Index));
            }
            return View(car);
        }

        // GET: Cars/Delete/5
        [Authorize]
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = _carService.GetCarById(id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _carService.DeleteCar(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult AddCarToWishlist(Guid Id)
        {
            var result = _wishlistService.getCarInfo(Id);
            if(result != null)
            {
                return View(result);
            }
            return View();
        }

        [HttpPost]
        public IActionResult AddCarToWishlist(AddToWishlistDTO model)
        {
            var customerId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var result = _wishlistService.AddCarToWishlist(customerId, model);

            if(result != null)
            {
                return RedirectToAction("Index", "Wishlists");
            }
            else { return View(model); }
        }

        private bool CarExists(Guid id)
        {
            return _carService.GetCarById(id) != null;
        }
    }
}
