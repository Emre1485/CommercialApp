using CommercialApp.Data;
using CommercialApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CommercialApp.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly AppDbContext _context;

        public DepartmentController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var dep = _context.Departments
                .Where(d=>d.State == true)
                .ToList();
            return View(dep);
        }

        [HttpGet]
        public IActionResult CreateDepartment()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateDepartment(Department department)
        {
            _context.Departments.Add(department);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteDepartment(int id)
        {
            var dep = _context.Departments.Find(id);
            dep.State = false;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateDepartment(int id)
        {
            var dep = _context.Departments.Find(id);
            return View("CreateDepartment", dep);
        }

        [HttpPost]
        public IActionResult UpdateDepartment(Department department)
        {
            var dep = _context.Departments.Find(department.Id);
            dep.Name = department.Name;
            dep.State = department.State;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var dpt = _context.Departments.Where(x=>x.Id == id)
                .Select(d=>d.Name)
                .FirstOrDefault();
            var emp = _context.Employees.Where(x => x.DepartmentId == id).ToList();

            ViewBag.depart = dpt;
            return View(emp);
        }

        public IActionResult EmployeeSales(int id)
        {
            var sal = _context.SaleTransactions
                .Include(x=>x.Products)
                .Include(x=>x.CustomerAccounts)
                .Where(x => x.EmployeesId == id).ToList();
            
            var pers = _context.Employees
                .Where(p => p.Id == id)
                .Select(p => p.Name + " " + p.Surname)
                .FirstOrDefault();
            ViewBag.per = pers;
            return View(sal);
        }
    }
}
