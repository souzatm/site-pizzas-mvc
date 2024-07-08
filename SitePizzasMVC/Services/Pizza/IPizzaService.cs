using SitePizzasMVC.Dto;
using SitePizzasMVC.Models;

namespace SitePizzasMVC.Services.Pizza
{
    public interface IPizzaService
    {
        Task<PizzaModel> CriarPizza(PizzaCriacaoDto pizzaCriacaoDto, IFormFile foto);
        Task<List<PizzaModel>> GetPizzas();
        Task<PizzaModel> GetPizzaPorId(int id);
        Task<List<PizzaModel>> GetPizzasFiltro(string? pesquisar);
        Task<PizzaModel> EditarPizza(PizzaModel pizza, IFormFile? foto);
        Task<PizzaModel> RemoverPizza(int id);
    }
}
