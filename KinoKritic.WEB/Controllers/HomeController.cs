using Microsoft.AspNetCore.Mvc;

namespace KinoKritic.WEB.Controllers
{
    public class HomeController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return RedirectToAction("GetAll", "Media");
        }
    }
}