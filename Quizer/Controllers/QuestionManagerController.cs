using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quizer.DataAccessLayer.Entities;
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
            ViewBag.Categories = _categoryService.GetCategoriesSelectList();
            ViewBag.CorrectAnswerNumbers = _answerService.GetCorrerctAnswerNumbersSelectList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(QuestionModelView model)
        {
            model.Category = _categoryService.Get(model.CategoryId);
            model.Question.Category = model.Category;
            model.Question.Answers = model.Answers;
            model.Question.CorrectAnswerId = model.Answers[model.CorrectAnswerId].Id;

            Question question = new Question
            {
                Text = model.Question.Text,
                Answers = model.Answers,
                CorrectAnswerId = model.Question.CorrectAnswerId,
                Category = model.Category,
                CategoryId = model.CategoryId
            };

            bool result = _questionService.Create(question);

            if (result)
                return RedirectToAction(nameof(Index));

            return View(model);
        }
    }
}