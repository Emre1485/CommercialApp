using CommercialApp.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CommercialApp.Controllers
{
	public class CustomerPanelController : Controller
	{
		private readonly AppDbContext _context;

		public CustomerPanelController(AppDbContext context)
		{
			_context = context;
		}

		[Authorize]
		public IActionResult Index()
		{
			//var cusMail = HttpContext.Session.GetString("Email");
			var cusMail = User.FindFirstValue(ClaimTypes.Name);
			var val = _context.CustomerAccounts
				.FirstOrDefault(x => x.Email == cusMail);
			ViewBag.Mail = cusMail;
            return View(val);
		}

		public IActionResult Orders()
		{
            var cusMail = User.FindFirstValue(ClaimTypes.Name);
			var id = _context.CustomerAccounts
				.Where(x => x.Email == cusMail.ToString())
				.Select(x => x.Id)
				.FirstOrDefault();

			var ords = _context.SaleTransactions
				.Include(x=>x.Products)
				.Where(x => x.Id == id)
				.ToList();
            return View(ords);
		}
	}
}
