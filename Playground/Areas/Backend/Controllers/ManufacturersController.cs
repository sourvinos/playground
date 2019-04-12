using Microsoft.AspNetCore.Mvc;

namespace Playground.Areas.Backend.Controllers
{
    [Area("Backend")]
    public class ManufacturersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
