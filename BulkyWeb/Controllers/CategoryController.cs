using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {
        ApplicationDBContext _db;

        public CategoryController(ApplicationDBContext db)
        {
            this._db = db;
        }

        public IActionResult Index()
        {
            var categoryDetails = _db.Category.ToList();
            return View(categoryDetails);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            // Custom Validation
            // Check if Category Name and Display Order is same or not
            if (category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "Category Name and Display Order cannot exactly match the same !!!");
                return View();
            }

            if (ModelState.IsValid)
            {
                _db.Category.Add(category);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
