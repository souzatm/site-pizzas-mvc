using Microsoft.EntityFrameworkCore;
using SitePizzasMVC.Models;

namespace SitePizzasMVC.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<PizzaModel> Pizzas { get; set; }
    }
}
