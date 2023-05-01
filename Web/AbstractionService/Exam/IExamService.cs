using Entity.Dto.Exam;

namespace Abstraction.Service.Exam
{
    public interface IExamService
    {
        List<ExamDto> GetExams();

        ExamDto GetExamById(int id);

        Task Create(ExamDto examDto);

        Task Update(ExamDto examDto);

        Task Delete(ExamDto examDto);
    }
}
