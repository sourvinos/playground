using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Playground.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Playground.Controllers
{
    public class CarsController : Controller
    {
        private PlaygroundContext _context;

        public CarsController(PlaygroundContext context) { _context = context; }

        // GET: Cars/Index
        public async Task<IActionResult> Index()
        {
            var cars = await _context.Cars
                .OrderBy(x => x.Manufacturer.Description)
                .Select(carViewModel => new CarViewModel
                {
                    CarId = carViewModel.CarId,
                    ManufacturerDescription = _context.Manufacturers.Where(x => x.Id == carViewModel.ManufacturerId).Select(x => x.Description).FirstOrDefault(),
                    ModelDescription = _context.Models.Where(x => x.Id == carViewModel.ModelId).Select(x => x.Description).FirstOrDefault(),
                    ColorDescription = _context.Colors.Where(x => x.Id == carViewModel.ColorId).Select(x => x.Description).FirstOrDefault(),
                }).ToListAsync();

            return View(cars);
        }

        // GET: Cars/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var car = await _context.Cars
                .Where(x => x.CarId == id)
                .GroupJoin(_context.Images,
                    o => o.CarId,
                    i => i.CarId, (c, images) => new CarViewModel
                    {
                        CarId = c.CarId,
                        ManufacturerDescription = _context.Manufacturers.Where(x => x.Id == c.ManufacturerId).Select(x => x.Description).FirstOrDefault(),
                        ColorDescription = _context.Colors.Where(x => x.Id == c.ColorId).Select(x => x.Description).FirstOrDefault(),
                        Images = images.OrderBy(x => x.SortOrder).ToList()
                    }).ToListAsync();

            return View(car);
        }

        // Helper: PopulateDropDown
        public IEnumerable<SelectListItem> PopulateDropDown(string tableName)
        {
            var selectList = new List<SelectListItem>();
            var items = _context.Base.FromSql("select * from " + tableName);

            foreach (var item in items)
            {
                selectList.Add(new SelectListItem() { Value = item.Id.ToString(), Text = item.Description });
            }

            return selectList;
        }
    }
}
