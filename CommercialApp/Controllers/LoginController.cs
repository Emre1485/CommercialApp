using CommercialApp.Data;
using CommercialApp.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CommercialApp.Controllers
{
    public class LoginController : Controller
    {
		private readonly AppDbContext _context;

		public LoginController(AppDbContext context)
		{
			_context = context;
		}

		public IActionResult Index()
        {
            return View();
        }
		[HttpGet]
		public PartialViewResult RegisterPartial()
		{
			return PartialView();
		}
		[HttpPost]
		public IActionResult RegisterPartial(CustomerAccount cus)
		{
			_context.CustomerAccounts.Add(cus);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
		public PartialViewResult LoginPartial()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult LoginPartial(CustomerAccount cus)
        {
            var val = _context.CustomerAccounts
                .FirstOrDefault(x => x.Email == cus.Email && x.Password == cus.Password);

            if (val != null)
            {
                // Create claims and sign in
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, val.Email)
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = false, // This is similar to 'false' in FormsAuthentication.SetAuthCookie
                };

                // Sign in the user
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties).Wait();

                // Redirect to the CustomerPanel after successful login
                return RedirectToAction("Index", "CustomerPanel");
            }

            // If login fails, return to the login view with an error message
            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return RedirectToAction("Index","Login");
        }

        public IActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AdminLogin(Admin adm)
        {
            var info = _context.Admins
                .FirstOrDefault(x => x.UserName == adm.UserName 
                             && x.Password == adm.Password);
            if(info != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, info.UserName),
                    new Claim("AdminID", info.Id.ToString()) // Extra claim example
                };
                // Create identity and principal
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                // Sign in
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);

                // Set Session value
                HttpContext.Session.SetString("UserName", info.UserName);

                return RedirectToAction("Index", "Category");
            }
            return RedirectToAction("Index", "Login");
        }
        public PartialViewResult EmployeeLoginPartial()
		{
			return PartialView();
		}
	}
}
