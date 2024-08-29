using CommercialApp.Data;
using CommercialApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using X.PagedList.Extensions;

namespace CommercialApp.Controllers
{
    public class ShipmentController : Controller
    {
        private readonly AppDbContext _context;

        public ShipmentController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string trackingNumber, int page = 1)
        {
            var cargos = _context.Cargos.AsQueryable();

            if (!string.IsNullOrEmpty(trackingNumber))
            {
                cargos = cargos.Where(x => x.TrackingNumber == trackingNumber);
            }

            var pagedCargos = cargos.ToPagedList(page, 10);
            ViewBag.CurrentFilter = trackingNumber;

            return View(pagedCargos);
        }


        public IActionResult CreateCargo()
        {
            string cargoCode = GenerateRandomCode();
            ViewBag.CargoCode = cargoCode;
            return View();
        }
        #region RandomCargoCode
        private string GenerateRandomCode()
        {
            Random random = new Random();
            const string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string numbers = "0123456789";

            string part1 = new string(GenerateRandomCharacters(random, letters, 3));
            string part2 = new string(GenerateRandomCharacters(random, numbers, 4));
            string part3 = new string(GenerateRandomCharacters(random, letters, 3));

            return $"{part1}{part2}{part3}";
        }

        private char[] GenerateRandomCharacters(Random random, string charset, int length)
        {
            char[] result = new char[length];
            for (int i = 0; i < length; i++)
            {
                result[i] = charset[random.Next(charset.Length)];
            }
            return result;
        }
        #endregion

        [HttpPost]
        public IActionResult CreateCargo(Cargo crg)
        {
            crg.Date = DateTime.UtcNow;
            _context.Cargos.Add(crg);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(string id)
        {

            var val = _context.CargoTrackings.Where(x => x.TrackingNumber == id)
                .OrderBy(x=>x.Date)
                .ToList();  
            return View(val);
        }
    }
}
