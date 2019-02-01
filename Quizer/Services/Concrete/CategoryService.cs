using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quizer.DataAccessLayer.Entities;
using Quizer.DataAccessLayer.Repositories.Abstract;
using Quizer.Services.Abstract;

namespace Quizer.Services.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> _categoryRepository;

        public CategoryService(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IEnumerable<Category> GetAll()
        {
            return _categoryRepository.GetAll();
        }

        public Category Get(int id)
        {
            return _categoryRepository.Get(id);
        }

        public bool Create(Category category)
        {
            try
            {
                _categoryRepository.Create(category);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e);
                return false;
            }

            return true;
        }

        public bool Update(Category category)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Category category)
        {
            try
            {
                _categoryRepository.Delete(category);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e);
                return false;
            }

            return true;
        }
    }
}
