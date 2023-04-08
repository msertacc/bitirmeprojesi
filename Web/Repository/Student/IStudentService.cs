using Entity.Dto.Student;

namespace Abstraction.Service.Student
{
	public interface IStudentService
	{
		List<StudentDto> GetStudents();

		Task Create(StudentDto studentDto);
	}
}
