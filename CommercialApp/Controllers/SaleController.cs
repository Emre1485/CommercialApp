using CommercialApp.Data;
using CommercialApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CommercialApp.Controllers
{
    public class SaleController : Controller
    {
        private readonly AppDbContext _context;

        public SaleController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var sales = _context.SaleTransactions
                .Include(x=>x.Products)
                .Include(x=>x.CustomerAccounts)
                .Include(x=>x.Employees)
                .ToList();
            if (sales == null)
                return View(new List<SaleTransaction>());
            return View(sales);
        }
        public IActionResult CreateSale()
        {
            var products = _context.Products.Select(p => new { p.Id, p.Name }).ToList();
            
            var customerAccounts = _context.CustomerAccounts
                .Select(ca => new { ca.Id, FullName = ca.Name + " " + ca.Surname }).ToList();
            
            var employees = _context.Employees
                .Select(e => new { e.Id, FullName = e.Name + " " + e.Surname }).ToList();

            ViewBag.Prods = new SelectList(products, "Id", "Name");
            ViewBag.CustomerAccs = new SelectList(customerAccounts, "Id", "FullName");
            ViewBag.Employees = new SelectList(employees, "Id", "FullName");
            return View();
        }

        [HttpPost]
        public IActionResult CreateSale(SaleTransaction sale)
        {
            sale.TransactionDate = sale.TransactionDate.ToUniversalTime();

            _context.SaleTransactions.Add(sale);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult UpdateSale(int id)
        {
            var sal = _context.SaleTransactions.Find(id);
            if (sal == null)
                return NotFound();

            var products = _context.Products.Select(p => new { p.Id, p.Name }).ToList();
            var customerAccounts = _context.CustomerAccounts
                .Select(ca => new { ca.Id, FullName = ca.Name + " " + ca.Surname }).ToList();
            var employees = _context.Employees
                .Select(e => new { e.Id, FullName = e.Name + " " + e.Surname }).ToList();

            ViewBag.Products = new SelectList(products, "Id", "Name");
            ViewBag.CustomerAccs = new SelectList(customerAccounts, "Id", "FullName");
            ViewBag.Employees = new SelectList(employees, "Id", "FullName");

            return View(sal);
        }

        [HttpPost]
        public IActionResult UpdateSale(SaleTransaction sale)
        {
            var sal = _context.SaleTransactions.Find(sale.Id);
            sal.ProductsId = sale.ProductsId;
            sal.Quantity = sale.Quantity;
            sal.Price = sale.Price;
            sal.TotalAmount = sale.TotalAmount;
            sal.CustomerAccountsId = sale.CustomerAccountsId;
            sal.EmployeesId = sale.EmployeesId;
            sal.TransactionDate = sale.TransactionDate;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult Details(int id)
        {
            var det = _context.SaleTransactions.Where(x => x.Id == id)
                .Include(x=>x.Products)
                .Include(x=>x.CustomerAccounts)
                .Include(x=>x.Employees)
                .ToList();

            return View(det);
        }
    }
}
