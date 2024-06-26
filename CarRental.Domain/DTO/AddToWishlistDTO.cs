using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Domain.DTO
{
    public class AddToWishlistDTO
    {
        public Guid SelectedCarId { get; set; }
        public string? SelectedCarModel { get; set; }
        public int Days { get; set; }
    }
}
