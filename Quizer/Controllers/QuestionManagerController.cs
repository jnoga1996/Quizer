using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quizer.Models;
using Quizer.Services.Abstract;

namespace Quizer.Controllers
{
    public class QuestionManagerController : Controller
    {
        private readonly IQuestionService _questionService;
        private readonly ICategoryService _categoryService;
        private readonly IAnswerService _answerService;

        public QuestionManagerController(IQuestionService questionService, ICategoryService categoryService,
            IAnswerService answerService)
        {
            _questionService = questionService;
            _categoryService = categoryService;
            _answerService = answerService;
        }

        public IActionResult Index()
        {
            List<QuestionModelView> questions = new List<QuestionModelView>();
            foreach (var question in _questionService.GetAll())
            {
                QuestionModelView model = new QuestionModelView
                {
                    Question = question,
                    Category = _categoryService.Get(question.CategoryId),
                    Answers = _answerService.GetAnswersForQuestion(question.Id).ToList()
                };

                questions.Add(model);
            }
            
            return View(questions);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(QuestionModelView model)
        {
            return RedirectToAction(nameof(Index));
        }
    }
}