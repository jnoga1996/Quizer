using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Quizer.DataAccessLayer.Entities;

namespace Quizer.Services.Abstract
{
    public interface IAnswerService
    {
        IEnumerable<Answer> GetAll();

        Answer Get(int id);

        IEnumerable<Answer> GetAnswersForQuestion(int questionId);

        bool Create(Answer answer);

        bool Delete(Answer answer);

        SelectList GetCorrerctAnswerNumbersSelectList();
    }
}
