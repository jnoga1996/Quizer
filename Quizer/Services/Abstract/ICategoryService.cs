using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Quizer.DataAccessLayer.Entities;

namespace Quizer.Services.Abstract
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAll();

        Category Get(int id);

        bool Create(Category category);

        bool Update(Category category);

        bool Delete(Category category);

        SelectList GetCategoriesSelectList();

    }
}
