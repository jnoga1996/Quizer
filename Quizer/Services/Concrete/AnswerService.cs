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
    public class AnswerService : IAnswerService
    {
        private readonly IRepository<Answer> _answerRepository;
        private readonly IRepository<Question> _questionRepository;

        public AnswerService(IRepository<Answer> answerRepository, IRepository<Question> questionRepository)
        {
            _answerRepository = answerRepository;
            _questionRepository = questionRepository;
        }

        public IEnumerable<Answer> GetAll()
        {
            return _answerRepository.GetAll();
        }

        public IEnumerable<Answer> GetAnswersForQuestion(int questionId)
        {
            return _answerRepository.GetAll().Where(q => q.QuestionId == questionId);
        }

        public Answer Get(int id)
        {
            return _answerRepository.Get(id);
        }

        public bool Create(Answer answer)
        {
            if (_answerRepository.Get(answer.Id) != null)
                return false;

            _answerRepository.Create(answer);

            return true;
        }

        public bool Delete(Answer answer)
        {
            if (_answerRepository.Get(answer.Id) == null)
                return false;

            _answerRepository.Delete(answer);

            return true;
        }

        public SelectList GetCorrerctAnswerNumbersSelectList()
        {
            List<SelectListItem> items = new List<SelectListItem>();

            for (int i = 1; i <= 4; i++)
            {
                SelectListItem item = new SelectListItem { Text = i.ToString(), Value = i.ToString() };
                if (i == 1) { item.Selected = true; }

                items.Add(item);
            }

            return new SelectList(items, "Text", "Value");
        }
    }
}
