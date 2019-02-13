using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Quizer.DataAccessLayer.Entities;

namespace Quizer.Models
{
    public class AnswerModelView
    {
        public int Id { get; set; }

        [MinLength(1, ErrorMessage = "Answer is too short.")]
        [MaxLength(256, ErrorMessage = "Answer is too long.")]
        [DisplayName("Answer")]
        public string Text { get; set; }

        [Required(ErrorMessage = "Answer must be connected with question.")]
        [DisplayName("Question")]
        public int QuestionId { get; set; }
    }
}
