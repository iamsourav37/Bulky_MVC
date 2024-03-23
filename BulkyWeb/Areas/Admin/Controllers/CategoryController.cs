using Bulky.DataAccess;
using Bulky.DataAccess.Repository;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IActionResult Index()
        {
            var categoryDetails = _categoryRepository.GetAll();
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
                _categoryRepository.Add(category);
                _categoryRepository.Save();
                TempData["Success"] = "Category created successfully !!!";
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

            var categoryFromDb = _categoryRepository.Get(x => x.Id == categoryId);

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
                _categoryRepository.Update(category);
                _categoryRepository.Save();
                TempData["Success"] = "Category updated successfully !!!";
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

            var categoryFromDb = _categoryRepository.Get(x => x.Id == categoryId);
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

            var categoryFromDb = _categoryRepository.Get(x => x.Id == categoryId);
            if (categoryFromDb is null)
            {
                return NotFound();
            }

            //Delete the Category
            _categoryRepository.Remove(categoryFromDb);
            _categoryRepository.Save();
            Console.WriteLine($"Delete Successfull. Category Details: {categoryFromDb.Id}, {categoryFromDb.Name}, {categoryFromDb.DisplayOrder}");
            TempData["Success"] = "Deleted successfully !!!";
            return RedirectToAction("Index");
        }
    }
}
