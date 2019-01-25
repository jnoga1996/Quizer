using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Quizer.DataAccessLayer.Entities
{
    public class Answer : BaseEntity
    {
        [Required(ErrorMessage = "Answer can't be empty.")]
        public string Text { get; set; }

        public int QuestionId { get; set; }
        public Question Question { get; set; }
    }
}
