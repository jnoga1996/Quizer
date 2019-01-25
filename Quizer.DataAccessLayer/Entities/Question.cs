using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Quizer.DataAccessLayer.Entities
{
    public class Question : BaseEntity
    {
        [Required(ErrorMessage = "Question can't be empty.")]
        public string Text { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int CorrectAnswerId { get; set; }

        public ICollection<Answer> Answers { get; set; }
    }
}
