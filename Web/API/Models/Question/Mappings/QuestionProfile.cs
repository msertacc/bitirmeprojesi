using AutoMapper;
using Entity.Dto.Question;

namespace API.Models.Question.Mappings
{
    public class QuestionProfile : Profile
    {
        public QuestionProfile()
        {
            this.CreateMap<QuestionCreateRequest, QuestionDto>();
        }

    }
}
