using CommercialApp.Data;
using CommercialApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CommercialApp.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public EmployeeController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult Index()
        {
            var emps = _context.Employees
                .Include(x=>x.Department)
                .OrderBy(x=>x.Id)
                .ToList(); 
            return View(emps);
        }

        public IActionResult CreateEmployee()
        {
            ViewBag.Departments = _context.Departments.ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(Employee employee)
        {
            if (employee.Department == null || employee.Department.Id == 0)
            {
                ModelState.AddModelError(string.Empty, "Lütfen bir seçenek seçiniz.");
                ViewBag.Departments = _context.Departments.ToList();
                return View(employee);
            }

            var department = _context.Departments.Find(employee.Department.Id);
            if (department == null)
            {
                ModelState.AddModelError(string.Empty, "Seçilen departman bulunamadı.");
                ViewBag.Departments = _context.Departments.ToList();
                return View(employee);
            }

            if (employee.Image != null && employee.Image.Length > 0)
            {
                string fileName = Path.GetFileName(employee.Image.FileName);
                string filePath = Path.Combine(_env.WebRootPath, "images", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await employee.Image.CopyToAsync(stream);
                }

                employee.ImageUrl = "/images/" + fileName; // Görselin URL'sini saklayın
            }

            employee.Department = department;
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public IActionResult UpdateEmployee (int id)
        {
            var emp = _context.Employees.Find(id);
            ViewBag.Departments = _context.Departments.ToList();
            return View("UpdateEmployee",emp);
        }
        [HttpPost]
        public IActionResult UpdateEmployee(Employee employee)
        {
            var emp = _context.Employees.Find(employee.Id);
            emp.Name = employee.Name;
            emp.Surname = employee.Surname;
            emp.Image = employee.Image;
            emp.DepartmentId = employee.DepartmentId;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult EmployeeDetail()
        {
            var employees = _context.Employees
                .Include(x=>x.Department)
                .ToList();
            return View(employees);
        }



    }
}
