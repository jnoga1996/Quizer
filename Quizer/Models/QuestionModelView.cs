using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Quizer.DataAccessLayer.Entities;

namespace Quizer.Models
{
    public class QuestionModelView
    {
        [Required(ErrorMessage = "Question is required.")]
        [DisplayName("Question")]
        public Question Question { get; set; }

        [Required(ErrorMessage = "Category is required.")]
        public Category Category { get; set; }

        public List<Answer> Answers { get; set; }

        public int CorrectAnswerId { get; set; }
        public int CategoryId { get; set; }

    }
}
