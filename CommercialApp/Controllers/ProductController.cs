using CommercialApp.Data;
using CommercialApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using X.PagedList.Extensions;

namespace CommercialApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string prd, int page = 1)
        {
            var products = _context.Products
                .Include(p => p.Category)
                .Where(x => x.State == true)
                .OrderBy(x => x.Id)
                .AsQueryable();

            if (!string.IsNullOrEmpty(prd))
            {
                products = products.Where(x => x.Name.Contains(prd));
            }
            var pagedProducts = products.ToPagedList(page, 10);
            ViewBag.CurrentFilter = prd;

            return View(pagedProducts);
        }


        public IActionResult ProductList()
        {
            var prods = _context.Products
                .Include(x=>x.Category)
                .ToList();
            return View(prods);
        }

        [HttpGet]
        public IActionResult CreateProduct()
        {
            ViewBag.Categories = _context.Categories.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DeleteProduct(int id)
        {
            var prod = _context.Products.Find(id);

            prod.State = false;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            var prod = _context.Products.Find(id);
            if(prod == null)
                return NotFound();
            ViewBag.Categories = _context.Categories.ToList();
            return View(prod);
        }

        [HttpPost]
        public IActionResult UpdateProduct(Product product)
        {
            var prd = _context.Products.Find(product.Id);
            if (prd != null)
            {
                prd.Name = product.Name;
                prd.Brand = product.Brand;
                prd.BuyingPrice = product.BuyingPrice;
                prd.Stock = product.Stock;
                prd.SellingPrice = product.SellingPrice;
                prd.CategoryId = product.CategoryId;
                prd.Image = product.Image;
                prd.State = product.State;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        public IActionResult SellProduct(int id)
        {

            List<SelectListItem> ls = (from x in _context.Employees.ToList()
                                       select new SelectListItem
                                       {
                                           Text = x.Name + " " + x.Surname,
                                           Value = x.Id.ToString()
                                       }).ToList();
            ViewBag.lis = ls;
            ViewBag.pid = _context.Products.Find(id).Id;
            ViewBag.prd = _context.Products.Find(id).Name;
            ViewBag.pric = _context.Products.Find(id).SellingPrice;
            return View();
        }
        [HttpPost]
        public IActionResult SellProduct(SaleTransaction sale)
        {
            sale.TransactionDate = DateTime.UtcNow;
            _context.SaleTransactions.Add(sale);
            _context.SaveChanges();
            return RedirectToAction("Index","Sale");
        }

    }
}
