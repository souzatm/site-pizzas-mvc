using Microsoft.AspNetCore.Mvc;
using SitePizzasMVC.Services.Pizza;

namespace SitePizzasMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPizzaService _pizzaService;

        public HomeController(IPizzaService pizzaService)
        {
            _pizzaService = pizzaService;
        }
        public async Task<IActionResult> Index(string? pesquisar)
        {
            if(pesquisar == null)
            {
                var pizza = await _pizzaService.GetPizzas();
                return View(pizza);
            }
            else
            {
                var pizzas = await _pizzaService.GetPizzasFiltro(pesquisar);
                return View(pizzas);
            }

            return View();
        }

    }
}
