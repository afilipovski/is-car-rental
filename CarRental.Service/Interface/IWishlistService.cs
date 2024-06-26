using CarRental.Domain.Domain;
using CarRental.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Service.Interface
{
    public interface IWishlistService
    {
        Wishlist AddCarToWishlist(string customerId, AddToWishlistDTO model);
        AddToWishlistDTO getCarInfo(Guid Id);
        WishlistDTO getWishlistDetails(string customerId);
        Boolean deleteFromWishlist(string customerId,  Guid? Id);
        Boolean rentCars(string customerId);
    }
}
