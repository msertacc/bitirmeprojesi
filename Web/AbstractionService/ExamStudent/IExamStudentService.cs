using Entity.Dto.ExamStudent;

namespace Abstraction.Service.ExamStudent
{
	public interface IExamStudentService
	{
		List<ExamStudentDto> GetExamByStudent(int userId);

        //ExamStudentDto GetExamStudentById(int id);

		//Task Create(ExamStudentDto studentDto);

		//Task Update(ExamStudentDto studentDto);

		//Task Delete(int id);
	}
}
