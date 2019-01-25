using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quizer.DataAccessLayer.Entities;
using Quizer.DataAccessLayer.Repositories.Abstract;
using Quizer.Models;

namespace Quizer.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly IRepository<Category> _categoriesRepository;

        public CategoriesController(IRepository<Category> categoriesRepository)
        {
            _categoriesRepository = categoriesRepository;
        }

        public IActionResult Index()
        {
            List<CategoryViewModel> categories = new List<CategoryViewModel>();

            foreach (var category in _categoriesRepository.GetAll())
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
    }
}