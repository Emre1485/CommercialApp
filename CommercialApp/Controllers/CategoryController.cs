using CommercialApp.Data;
using CommercialApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using X.PagedList.Extensions;


namespace CommercialApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index(int page = 1)
        {
            var categories = _context.Categories.AsQueryable().ToPagedList(page, 5);
            
            return View(categories);
        }


        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult CreateCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }




        // DELETE
        [HttpPost]
        public IActionResult DeleteCategory(int id)
        {
            var cat = _context.Categories.Find(id);
            if (cat == null) 
                return NotFound();

            _context.Categories.Remove(cat);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateCategory(int id)
        {
            var category = _context.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        public IActionResult UpdateCategory(Category category)
        {
            var cat = _context.Categories.Find(category.Id);
            cat.Name = category.Name;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }



    }
}
