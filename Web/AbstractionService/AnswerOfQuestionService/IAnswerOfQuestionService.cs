﻿using Entity.Dto.AnswerOfQuestion;
using Entity.Dto.Choice;
using Entity.Dto.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction.Service.AnswerOfQuestionService
{
    public interface IAnswerOfQuestionService
    {
        Task Create(AnswerOfQuestionDto answerOfQuestionDto);
    }
}
