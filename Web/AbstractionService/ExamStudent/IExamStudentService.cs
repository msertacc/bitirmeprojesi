using Entity.Dto.ExamUser;
using Entity.Dto.Question;

namespace Abstraction.Service.ExamUser
{
	public interface IExamUserService
	{
		List<ExamUserDto> GetExamByUser(string id);
        IEnumerable<ResultExamDto> GetResultsForExams(Guid userid);

        //ExamUserDto GetExamUserById(int id);

        //Task Create(ExamUserDto userDto);

        //Task Update(ExamUserDto userDto);

        //Task Delete(int id);
    }
}
