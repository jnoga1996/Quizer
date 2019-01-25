using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Quizer.DataAccessLayer.Entities;

namespace Quizer.Models
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        [DisplayName("Category name")]
        [MaxLength(256, ErrorMessage = "Name is too long.")]
        [MinLength(2, ErrorMessage = "Name is too short.")]
        public string Name { get; set; }

        public ICollection<Question> Questions { get; set; }
    }
}
