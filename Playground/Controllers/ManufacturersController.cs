using Microsoft.AspNetCore.Mvc;
using Playground.Interfaces;
using Playground.Models;

namespace Playground.Controllers
{
    public class ManufacturersController : Controller
    {
        private IRepository<Manufacturer> manufacturerRepository;

        public ManufacturersController(IRepository<Manufacturer> manufacturerRepository)
        {
            this.manufacturerRepository = manufacturerRepository;
        }

        public IActionResult Index()
        {
            return View(manufacturerRepository.GetAll());
        }
    }
}
