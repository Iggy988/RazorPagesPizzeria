using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPizzeria.Data;
using RazorPizzeria.Models;

namespace RazorPizzeria.Pages.Checkout
{
    //bindProperties - vezemo props za View, tj da budu dostupne u View
    // koristimo iznad class koja sadrzi props
    // za vezanje props za Get request
    [BindProperties(SupportsGet =true)]
    public class CheckoutModel : PageModel
    {
        //moze BindProperty za svaki pojedinacni prop
        public string PizzaName { get; set; }
        public float PizzaPrice { get; set; }
        public string ImageTitle { get; set; }

        //pravimo varijablu koja ce sadrzavati DB
        private readonly ApplicationDBContext _context;
        // u contructor budu injectovani every service (dependency injection)
        public CheckoutModel(ApplicationDBContext context)
        {
            _context= context;
        }

        public void OnGet()
        {
            //provjeravamo da li imamo ime pice
            // ako nema override sa custom
            if (string.IsNullOrWhiteSpace(PizzaName))
            {
                PizzaName = "Custom";
            }
            if(string.IsNullOrWhiteSpace(ImageTitle))
            {
                ImageTitle = "Create";
            }

            PizzaOrder pizzaOrder = new PizzaOrder();
            //vezemo model element za prop
            pizzaOrder.PizzaName = PizzaName;
            pizzaOrder.BasePrice = PizzaPrice;

            _context.PizzaOrders.Add(pizzaOrder);
            //kad god modifikujemo db(dodamo, brisemo elemente), moramo snimiti promjenu
            _context.SaveChanges();

        }
    }
}
