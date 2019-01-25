using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Quizer.DataAccessLayer.Entities
{
    public class Category : BaseEntity
    {
        [Required(ErrorMessage = "Category name can't be empty.")]
        public string Name { get; set; }

        public ICollection<Question> Questions { get; set; }
    }
}
