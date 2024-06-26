using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarRental.Repository;
using CarRental.Domain.Domain;
using System.Security.Claims;
using System.Data;
using CarRental.Domain.DTO;
using CarRental.Service.Interface;

namespace CarRental.Web.Controllers
{
    public class WishlistsController : Controller
    {
        private readonly IWishlistService _wishlistService;

        public WishlistsController(IWishlistService wishlistService)
        {
            _wishlistService = wishlistService;
        }

        // GET: Wishlists
        public async Task<IActionResult> Index()
        {
            var customerId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? null;

            return View(_wishlistService.getWishlistDetails(customerId??"")); 
        }

        // GET: Wishlists/Details/5
     
        // GET: Wishlists/Delete/5
        public async Task<IActionResult> DeleteCarFromWishlist(Guid? carId)
        {
            var customerId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? null;

            var result = _wishlistService.deleteFromWishlist(customerId, carId);

            return RedirectToAction("Index", "Wishlists");
        }

        public async Task<IActionResult> Rent()
        {
            var customerId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? null;

            var result = _wishlistService.rentCars(customerId??"");
            
            return RedirectToAction("Index", "Wishlists");
        }


    }
}
