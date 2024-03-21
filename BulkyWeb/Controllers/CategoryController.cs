using BulkyWeb.Data;
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
    }
}
