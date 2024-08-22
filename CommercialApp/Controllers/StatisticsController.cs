using CommercialApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CommercialApp.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly AppDbContext _context;

        public StatisticsController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.d1 = _context.CustomerAccounts.Count().ToString();
            ViewBag.d2 = _context.Products.Count().ToString();
            ViewBag.d3 = _context.Employees.Count().ToString();
            ViewBag.d4 = _context.Categories.Count().ToString();

            ViewBag.d5 = _context.Products.Sum(x => x.Stock).ToString();
            ViewBag.d6 = (from x in _context.Products select x.Brand).Distinct().Count().ToString();
            ViewBag.d7 = _context.Products.Count(x => x.Stock <= 20).ToString();
            ViewBag.d8 = _context.Products
                .Where(x => x.SellingPrice == _context.Products.Max(y => y.SellingPrice))
                .Select(x => x.Brand + " " + x.Name)
                .FirstOrDefault();
            // select Name from products where Max(SellingPrice) 
            //ViewBag.d9 = _context.Products.Min(x=>x.SellingPrice).ToString();
            // tekrar don burayı duzenle
            ViewBag.d10 = _context.Products
    .FromSqlRaw(@"
        SELECT p.""Name"",p.""Brand"", SUM(s.""Quantity"") AS TotalQuantitySold
        FROM ""SaleTransactions"" s
        INNER JOIN ""Products"" p ON s.""ProductsId"" = p.""Id""
        GROUP BY p.""Name"", p.""Brand""
        ORDER BY TotalQuantitySold DESC
        LIMIT 1")
    .Select(p => p.Brand + " "+ p.Name)
    .FirstOrDefault();

            ViewBag.d11 = _context.SaleTransactions.Sum(x => x.TotalAmount).ToString();
            ViewBag.d12 = _context.SaleTransactions
                .Where(x => x.TransactionDate == DateTime.Today)
                .Sum(x => (decimal?)x.TotalAmount)
                .ToString();
            var startOfDay = DateTime.Today.ToUniversalTime();
            var endOfDay = startOfDay.AddDays(1).AddTicks(-1).ToUniversalTime();

            ViewBag.d13 = _context.SaleTransactions
                .Where(x => x.TransactionDate >= startOfDay && x.TransactionDate <= endOfDay)
                .Sum(x => x.TotalAmount)
                .ToString();
            return View();
        }
    }
}
