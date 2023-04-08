using AutoMapper;
using Entity.Dto.Student;

namespace Service.Student.Mappings
{
	public class StudentProfile:Profile
	{
		public StudentProfile()
		{
			this.CreateMap<Entity.Domain.Student.Student, StudentDto>();
			this.CreateMap<StudentDto,	Entity.Domain.Student.Student>();
			//this.CreateMap<StudentViewModel, StudentDto>();
			//this.CreateMap<StudentDto, StudentViewModel>();
		}
	}
}
