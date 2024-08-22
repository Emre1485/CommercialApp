using CommercialApp.Data;
using Microsoft.AspNetCore.Mvc;

namespace CommercialApp.Controllers
{
    public class GalleryController : Controller
    {
        private readonly AppDbContext _context;

        public GalleryController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var prods = _context.Products.ToList();
            return View(prods);
        }
    }
}
