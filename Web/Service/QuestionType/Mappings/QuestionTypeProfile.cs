using AutoMapper;
using Entity.Dto.Course;
using Entity.Dto.QuestionType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.QuestionType.Mappings
{
    public class QuestionTypeProfile : Profile
    {
        public QuestionTypeProfile()
        {
            this.CreateMap<Entity.Domain.QuestionType.QuestionType, QuestionTypeDto>();
            this.CreateMap<QuestionTypeDto, Entity.Domain.QuestionType.QuestionType>();
        }
    }
}
