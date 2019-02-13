using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Quizer.DataAccessLayer.Entities;
using Quizer.DataAccessLayer.Repositories.Abstract;
using Quizer.Services.Abstract;

namespace Quizer.Services.Concrete
{
    public class QuestionService : IQuestionService
    {
        private readonly IRepository<Question> _questionRepository;

        public QuestionService(IRepository<Question> questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public IEnumerable<Question> GetAll()
        {
            return _questionRepository.GetAll();
        }

        public Question Get(int id)
        {
            return _questionRepository.Get(id);
        }

        public SelectList GetSelectList()
        {
            return new SelectList(_questionRepository.GetAll(), "Id", "Text");
        }

        public bool Create(Question question)
        {
            try
            {
                _questionRepository.Create(question);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex);
                return false;
            }

            return true;
        }
    }
}
