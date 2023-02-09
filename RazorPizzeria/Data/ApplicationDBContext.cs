using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using RazorPizzeria.Models;

namespace RazorPizzeria.Data
{
    public class ApplicationDBContext:DbContext
    {
        public DbSet<PizzaOrder> PizzaOrders { get; set; }
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
    }
}
