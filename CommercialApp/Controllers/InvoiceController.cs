using CommercialApp.Data;
using CommercialApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            return View(inv);
        }

        public IActionResult CreateInvoice()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateInvoice(Invoice inv)
        {
            inv.Date = inv.Date.ToUniversalTime();
            inv.Sender = inv.Sender.ToUpper();
            inv.Receiver = inv.Receiver.ToUpper();
            _context.Add(inv);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult UpdateInvoice(int id)
        {
            var inv = _context.Invoices.Find(id);
            return View("UpdateInvoice",inv);
        }

        [HttpPost]
        public IActionResult UpdateInvoice(Invoice invoice)
        {
            var inv = _context.Invoices.Find(invoice.Id);
            inv.InvoiceSeries = invoice.InvoiceSeries;
            inv.InvoiceNumber = invoice.InvoiceNumber;
            inv.Sender = invoice.Sender;
            inv.Receiver = invoice.Receiver;
            inv.TaxOffice = invoice.TaxOffice;
            inv.Time = invoice.Time;
            inv.Date = invoice.Date.ToUniversalTime();
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var det = _context.InvoiceItems.Where(x => x.InvoiceId == id).ToList();
            return View(det);
        }

        [HttpGet]
        public IActionResult CreateItem()
        {
            ViewBag.Invoices = new SelectList(_context.Invoices, "Id", "Description");
            return View();
        }

        [HttpPost]
        public IActionResult CreateItem(InvoiceItem item)
        {
            if (ModelState.IsValid)
            {
                _context.InvoiceItems.Add(item);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Invoices = new SelectList(_context.Invoices, "Id", "Description");
            return View(item);
        }
    }
}
