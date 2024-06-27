using CarRental.Service.Interface;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Drawing.Charts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Web.Controllers
{
    public class RentalsController : Controller
    {
        private readonly IRentalService _rentalService;

        public RentalsController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        // GET: RentalsController
        public ActionResult Index()
        {
            return View(_rentalService.GetRentals());
        }

        [HttpGet]
        public FileContentResult Export()
        {
            string fileName = "AllRentals.xlsx";
            string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

            using (var workBook = new XLWorkbook())
            {
                IXLWorksheet worksheet = workBook.Worksheets.Add("Rentals");

                worksheet.Cell(1, 1).Value = "Rental ID";
                worksheet.Cell(1, 2).Value = "Customer";

                var rentals = _rentalService.GetRentals();

                for (int i = 0; i < rentals.Count(); i++)
                {
                    var order = rentals[i];
                    worksheet.Cell(i + 2, 1).Value = order.Id.ToString();
                    worksheet.Cell(i + 2, 2).Value = order.Customer.FirstName + " " + order.Customer.LastName;

                    for (int j = 0; j < order.CarsInRental.Count(); j++)
                    {
                        worksheet.Cell(1, j + 3).Value = "Product - " + (j + 1);
                        worksheet.Cell(i + 2, j + 3).Value = order.CarsInRental.ElementAt(j).RentedCar.CarModel;

                    }
                }

                using (var stream = new MemoryStream())
                {
                    workBook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, contentType, fileName);
                }
            }

        }
    }
}
