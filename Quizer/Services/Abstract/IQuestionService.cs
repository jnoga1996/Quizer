using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quizer.DataAccessLayer.Entities;

namespace Quizer.Services.Abstract
{
    public interface IQuestionService
    {
        IEnumerable<Question> GetAll();
    }
}
