using Microsoft.AspNetCore.Mvc;

namespace SitePizzasMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
