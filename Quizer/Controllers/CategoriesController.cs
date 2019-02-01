using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quizer.DataAccessLayer.Entities;
using Quizer.DataAccessLayer.Repositories.Abstract;
using Quizer.Models;
using Quizer.Services.Abstract;

namespace Quizer.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;

        }

        public IActionResult Index()
        {
            List<CategoryViewModel> categories = new List<CategoryViewModel>();

            foreach (var category in _categoryService.GetAll())
            {
                CategoryViewModel model = new CategoryViewModel
                {
                    Id = category.Id,
                    Name = category.Name
                };

                categories.Add(model);
            }

            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CategoryViewModel model)
        {
            ModelState.Remove("Id");
            ModelState.Remove("Questions");
            if (ModelState.IsValid)
            {
                Category category = new Category
                {
                    Name = model.Name
                };

                //_categoriesRepository.Create(category);
                _categoryService.Create(category);

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            //Category categoryToDelete = _categoriesRepository.Get(id);
            Category categoryToDelete = _categoryService.Get(id);
            if (categoryToDelete != null)
            {
                //_categoriesRepository.Delete(categoryToDelete);
                _categoryService.Delete(categoryToDelete);
                return RedirectToAction(nameof(Index));
            }

            return NotFound();
        }
    }
}