using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPizzeria.Data;
using RazorPizzeria.Models;

namespace RazorPizzeria.Pages.Orders
{
    public class OrdersModel : PageModel
    {
        public List<PizzaOrder> PizzaOrders = new List<PizzaOrder>();

        // ako hocemo da imamo Orders iz DB(context) moramo da koristimo Dependency Injection
        private readonly ApplicationDBContext _context;
        public OrdersModel(ApplicationDBContext context)

        {
            _context = context;
        }
        public void OnGet()
        {
            //ulazimo u model i pretvaramo elemente u listu i dodjeljujemo listi PizzaOrders
            // ne snimamo zato sto samo pristupamo data (readonly), a ne modifikujemo
            PizzaOrders = _context.PizzaOrders.ToList();
        }
    }
}
