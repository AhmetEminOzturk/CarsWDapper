using Microsoft.AspNetCore.Mvc;

namespace CarsWDapper.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
