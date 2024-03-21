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
            _db.Category.Add(category);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
