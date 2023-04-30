using AutoMapper;
using Entity.Dto.Exam;

namespace Service.Exam.Mappings
{
    public class ExamProfile : Profile
    {
        public ExamProfile()
        {
            this.CreateMap<Entity.Domain.Exam.Exam, ExamDto>();
            this.CreateMap<ExamDto, Entity.Domain.Exam.Exam>();
        }
    }
}
