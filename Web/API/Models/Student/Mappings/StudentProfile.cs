using AutoMapper;
using Entity.Dto.Student;

namespace API.Models.Student.Mappings
{
	public class StudentProfile:Profile
	{
		public StudentProfile()
		{
			this.CreateMap<StudentCreateRequest, StudentDto>();
			this.CreateMap<StudentUpdateRequest, StudentDto>();
		}
	}
}
