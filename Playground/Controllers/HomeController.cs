using Microsoft.AspNetCore.Mvc;
using Playground.Interfaces;

namespace Playground.Controllers
{
    public class HomeController : Controller
    {
        private IClock clock;

        public HomeController(IClock clock)
        {
            this.clock = clock;
        }

        public IActionResult Index()
        {
            return View(clock);
        }

        public IActionResult FlexBox()
        {
            return View();
        }

        public IActionResult Trani()
        {
            return View();
        }
    }
}
