using AutoMapper;
using Entity.Dto.Course;
using Entity.Dto.Exam;

namespace API.Models.Exam.Mappings
{
    public class ExamProfile : Profile
    {
        public ExamProfile()
        {
            this.CreateMap<ExamCreateRequest, ExamDto>();
        }
    }
}
