using CommercialApp.Data;
using CommercialApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CommercialApp.Controllers
{
    public class CustomerAccountController : Controller
    {
       private readonly AppDbContext _context;

        public CustomerAccountController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var val = _context.CustomerAccounts
                .Where(x => x.State == true)
                .OrderBy(x => x.Id)
                .ToList();
            return View(val);
        }

        public IActionResult CreateCustomerAccount()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCustomerAccount(CustomerAccount cacc)
        {
            _context.CustomerAccounts.Add(cacc);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DeleteCustomerAccount(int id)
        {
            var cacc = _context.CustomerAccounts.Find(id);
            cacc.State = false;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult UpdateCustomerAccount(int id)
        {
            var cacc = _context.CustomerAccounts.Find(id);
            return View("UpdateCustomerAccount", cacc);
        }
        [HttpPost]
        public IActionResult UpdateCustomerAccount(CustomerAccount cacc)
        {
            if (!ModelState.IsValid)
                return View("UpdateCustomerAccount");
            
            var cust = _context.CustomerAccounts.Find(cacc.Id);
            cust.Name = cacc.Name;
            cust.Surname = cacc.Surname;
            cust.City = cacc.City;
            cust.Email = cacc.Email;

            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        //public IActionResult Details(int id)
        //{
        //    var vals = _context.SaleTransactions
        //        .Where(x => x.CustomerAccountsId == id)
        //        .ToList();
        //    return View(vals);
        //}
        public IActionResult Details(int id)
        {
            var vals = _context.SaleTransactions
                .Include(x => x.Products)
                .Include(x => x.Employees)
                .Where(x => x.CustomerAccountsId == id)
                .ToList();
            var cus = _context.CustomerAccounts
                .Where(x => x.Id == id)
                .Select(x=> x.Name + " " + x.Surname)
                .FirstOrDefault();
            ViewBag.cac = cus;
            return View(vals);
        }

    }
}
