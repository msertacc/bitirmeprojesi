using AutoMapper;
using Entity.Dto.AnswerOfQuestion;

namespace API.Models.AnswerOfQuestion.Mappings
{
    public class AnswerOfQuestionProfile:Profile
    {
        public AnswerOfQuestionProfile()
        {
            this.CreateMap<AnswerOfQuestionCreateRequest, AnswerOfQuestionDto>();
            this.CreateMap<AnswerDto, AnswerRequest>();
            this.CreateMap<AnswerRequest, AnswerDto>();
        }
    }
}
