using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Quizer.DataAccessLayer.Entities;

namespace Quizer.Models
{
    public class QuestionModelView
    {
        [Required(ErrorMessage = "Question is required.")]
        public Question Question { get; set; }

        [Required(ErrorMessage = "Category is required.")]
        public Category Category { get; set; }

        public List<Answer> Answers { get; set; }
        
    }
}
