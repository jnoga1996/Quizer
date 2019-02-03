﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Quizer.DataAccessLayer.Entities;

namespace Quizer.Services.Abstract
{
    public interface IQuestionService
    {
        IEnumerable<Question> GetAll();

        Question Get(int id);

        SelectList GetSelectList();
    }
}
