using CommercialApp.Data;
using Microsoft.AspNetCore.Mvc;

namespace CommercialApp.Controllers
{
    public class ProductDetailController : Controller
    {
        private readonly AppDbContext _context;

        public ProductDetailController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var prods = _context.Products.Where(x=>x.Id == 3).ToList();
            return View(prods);
        }
    }
}
