﻿using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.AskUs;

namespace Business.Interfaces
{
    interface IQuestionBAL
    {
        List<Question> GetAllQuestion();
        void AddQuestion(Question question);

        Question GetQuestionById(long id);

    }
}
