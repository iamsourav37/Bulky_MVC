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

        public IActionResult Edit(int? categoryId)
        {
            if (categoryId == null)
            {
                return NotFound();
            }

            var categoryFromDb = _db.Category.FirstOrDefault(x => x.Id == categoryId);

            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _db.Category.Update(category);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? categoryId)
        {
            if (categoryId is null)
            {
                return NotFound();
            }

            var categoryFromDb = _db.Category.FirstOrDefault(cate => cate.Id == categoryId);
            if (categoryFromDb is null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteCategory(int? categoryId)
        {
            if (categoryId is null)
            {
                return NotFound();
            }

            var categoryFromDb = _db.Category.FirstOrDefault(cate => cate.Id == categoryId);
            if (categoryFromDb is null)
            {
                return NotFound();
            }

            //Delete the Category
            _db.Category.Remove(categoryFromDb);
            _db.SaveChanges();
            Console.WriteLine($"Delete Successfull. Category Details: {categoryFromDb.Id}, {categoryFromDb.Name}, {categoryFromDb.DisplayOrder}");
            return RedirectToAction("Index");
        }
    }
}
