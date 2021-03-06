﻿using System;
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
                    Answers = _answerService.GetAnswersForQuestion(question.Id).ToList(),
                    CorrectAnswerId = question.CorrectAnswerId,
                    CategoryId = question.CategoryId
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
            
            int correctAnswerId = model.Answers[model.CorrectAnswerId].Id;
            Answer correctAnswer = new Answer
            {
                Text = model.Answers[correctAnswerId].Text,
                Question = model.Question
            };
            bool correctAnswerCreated = _answerService.Create(correctAnswer);

            Question question = new Question
            {
                Text = model.Question.Text,
                Answers = model.Answers,
                CorrectAnswerId = correctAnswer.Id,
                Category = model.Category,
                CategoryId = model.CategoryId
            };

            bool questionCreated = _questionService.Create(question);

            if (correctAnswerCreated && questionCreated)
                return RedirectToAction(nameof(Index));

            return View(model);
        }
    }
}