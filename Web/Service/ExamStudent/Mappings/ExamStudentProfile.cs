using AutoMapper;
using Entity.Dto.ExamStudent;

namespace Service.ExamStudent.Mappings
{
    public class ExamStudentProfile:Profile
    {
        public ExamStudentProfile()
        {
            this.CreateMap<Entity.Domain.ExamStudent.ExamStudent, ExamStudentDto>();
			this.CreateMap<ExamStudentDto, Entity.Domain.ExamStudent.ExamStudent>();			
		}
    }
}
