using CommercialApp.Data;
using CommercialApp.Models;
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
            var product_PDetail = new Product_PDetail
            {
                ProductVal = _context.Products.Where(x => x.Id == 5).ToList(),
                PDetailVal = _context.PDetails.Where(x => x.Id == 5).ToList()
            };

            return View(product_PDetail);
        }

    }
}
