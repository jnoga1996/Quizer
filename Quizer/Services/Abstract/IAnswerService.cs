using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quizer.DataAccessLayer.Entities;

namespace Quizer.Services.Abstract
{
    public interface IAnswerService
    {
        IEnumerable<Answer> GetAll();

        IEnumerable<Answer> GetAnswersForQuestion(int questionId);
    }
}
