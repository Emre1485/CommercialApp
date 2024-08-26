using CommercialApp.Data;
using Microsoft.AspNetCore.Mvc;

namespace CommercialApp.Controllers
{
    public class ToDoController : Controller
    {
        private readonly AppDbContext _context;

        public ToDoController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.v1 = _context.Products.Count().ToString();
            ViewBag.v2 = _context.Categories.Count().ToString();
            ViewBag.v3 = _context.CustomerAccounts.Count().ToString();
            ViewBag.v4 = (from x in _context.CustomerAccounts select x.City)
                .Distinct().Count().ToString();

            var todos = _context.ToDos.ToList();
            return View(todos);
        }
    }
}
