using AutoMapper;
using Entity.Dto.AnswerOfQuestion;
using Entity.Dto.Choice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.AnswerOfQuestion.Mappings
{
    public class AnswerOfQuestionProfile:Profile
    {
        public AnswerOfQuestionProfile()
        {
            this.CreateMap<Entity.Domain.AnswerOfQuestion.AnswerOfQuestion, AnswerOfQuestionDto>();
            this.CreateMap<AnswerOfQuestionDto, Entity.Domain.AnswerOfQuestion.AnswerOfQuestion>();
        }
    }
}
