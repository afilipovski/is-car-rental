using CarRental.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Service.Interface
{
    public interface IRentalService
    {
        public List<Rental> GetRentals();
    }
}
