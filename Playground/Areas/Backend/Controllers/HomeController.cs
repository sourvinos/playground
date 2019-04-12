using Microsoft.AspNetCore.Mvc;

namespace Playground.Areas.Backend.Controllers
{
    [Area("Backend")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
