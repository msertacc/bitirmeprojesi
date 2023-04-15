using Entity.Dto.Student;

namespace Abstraction.Service.Student
{
	public interface IStudentService
	{
		List<StudentDto> GetStudents();

		StudentDto GetStudentById(int id);

		Task Create(StudentDto studentDto);

		Task Update(StudentDto studentDto);

		Task Delete(int id);
	}
}
