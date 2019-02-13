using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Quizer.Models
{
    public class AnswersModelView
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Answers can't be empty.")]
        public List<AnswerModelView> Answers { get; set; }
    }
}
