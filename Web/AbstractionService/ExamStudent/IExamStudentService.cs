using Entity.Dto.ExamUser;
using Entity.Dto.Question;

namespace Abstraction.Service.ExamUser
{
	public interface IExamUserService
	{
		List<ExamUserDto> GetExamByUser(string id);
        IEnumerable<ResultExamDto> GetResultsForExams(Guid userid);
        Task Create(ExamUserDto examUserDto);
        Task Update(int? examId, Guid? userId);
    }
}
