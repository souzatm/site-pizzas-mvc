using Microsoft.AspNetCore.Mvc;
using SitePizzasMVC.Dto;
using SitePizzasMVC.Models;
using SitePizzasMVC.Services.Pizza;

namespace SitePizzasMVC.Controllers
{
    public class PizzaController : Controller
    {
        private readonly IPizzaService _pizzaService;

        public PizzaController(IPizzaService pizzaService)
        {
            _pizzaService = pizzaService;
        }

        public async Task<IActionResult> Index()
        {
            var pizzas = await _pizzaService.GetPizzas();
            return View(pizzas);
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        public async Task<IActionResult> Editar(int id)
        {
            var pizza = await _pizzaService.GetPizzaPorId(id);
            return View(pizza);
        }

        public async Task<IActionResult> Remover(int id)
        {
            var pizza = await _pizzaService.RemoverPizza(id);
            return RedirectToAction("Index", "Pizza");
        }

        public async Task<IActionResult> Detalhes(int id)
        {
            var pizza = await _pizzaService.GetPizzaPorId(id);
            return View(pizza);
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(PizzaCriacaoDto pizzaCriacaoDto, IFormFile foto)
        {
            if (ModelState.IsValid)
            {
                var pizza = await _pizzaService.CriarPizza(pizzaCriacaoDto, foto);
                return RedirectToAction("Index", "Pizza");
            }
            else
            {
                return View(pizzaCriacaoDto);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Editar(PizzaModel pizzaModel, IFormFile? foto)
        {
            if (ModelState.IsValid)
            {
                var pizza = await _pizzaService.EditarPizza(pizzaModel, foto);
                return RedirectToAction("Index", "Pizza");
            }
            else
            {
                return View(pizzaModel);
            }
        }
    }
}
