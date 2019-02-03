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
    public class AnswersController : Controller
    {
        private readonly IAnswerService _answerService;
        private readonly IQuestionService _questionService;

        public AnswersController(IAnswerService answerService, IQuestionService questionService)
        {
            _answerService = answerService;
            _questionService = questionService;
        }

        public IActionResult Index()
        {
            List<AnswerModelView> answers = new List<AnswerModelView>();

            foreach (var answer in _answerService.GetAll())
            {
                AnswerModelView model = new AnswerModelView
                {
                    Id = answer.Id,
                    Text = answer.Text,
                    QuestionId = answer.QuestionId
                };

                answers.Add(model);
            }

            return View(answers);
        }

        public IActionResult Create()
        {
            ViewBag.QuestionSelectList = _questionService.GetSelectList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(AnswerModelView model)
        {
            if (ModelState.IsValid)
            {
                Answer answer = new Answer
                {
                    Text = model.Text,
                    Question = _questionService.Get(model.QuestionId),
                    QuestionId = model.QuestionId
                };

                _answerService.Create(answer);

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            Answer answerToDelete = _answerService.Get(id);

            if (answerToDelete != null)
            {
                _answerService.Delete(answerToDelete);

                return RedirectToAction(nameof(Index));
            }

            return NotFound();
        }
    }
}