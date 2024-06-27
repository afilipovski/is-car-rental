using CarRental.Domain.Domain;
using CarRental.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Repository.Interface
{
    public interface IRentalRepository
    {
        IEnumerable<Rental> GetAll();
    }
}
