using Microsoft.AspNetCore.Mvc;
using Playground.Interfaces;
using Playground.Models;

namespace Playground.Controllers
{
    public class ModelsController : Controller
    {
        private IRepository<Model> modelRepository;

        public ModelsController(IRepository<Model> modelRepository)
        {
            this.modelRepository = modelRepository;
        }

        public IActionResult Index()
        {
            return View(modelRepository.GetAll());
        }
    }
}
