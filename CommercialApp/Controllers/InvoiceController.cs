using CommercialApp.Data;
using Microsoft.AspNetCore.Mvc;

namespace CommercialApp.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly AppDbContext _context;

        public InvoiceController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var inv = _context.Invoices.ToList();
            return View();
        }
    }
}
