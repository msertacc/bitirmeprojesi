using AutoMapper;
using Entity.Dto.Course;
using Entity.Dto.Question;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Question.Mappings
{
    public class QuestionProfile : Profile
    {
        public QuestionProfile()
        {
            this.CreateMap<Entity.Domain.Question.Question, QuestionDto>();
            this.CreateMap<QuestionDto, Entity.Domain.Question.Question>();
        }
    }
}
