using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Quizer.DataAccessLayer.Entities;

namespace Quizer.DataAccessLayer
{
    public static class DbInitializer
    {
        public static Category[] Categories { get; set; } =
        {
            new Category {Id = 1, Name = "Mathematics"},
            new Category {Id = 2, Name = "Overall knowledge"}
        };


        public static Answer[] Answers { get; set; } =
        {
            new Answer {Id = 1, Text = "4", QuestionId = 1},
            new Answer {Id = 2, Text = "3", QuestionId = 1},
            new Answer {Id = 3, Text = "2", QuestionId = 1},
            new Answer {Id = 4, Text = "1", QuestionId = 1}
        };


        public static Question[] Questions { get; set; } =
        {
            new Question {Id = 1, CategoryId = 1, CorrectAnswerId = 1, Text = "2 + 2 = ?"}
        };


    }
}
