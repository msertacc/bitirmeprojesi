using Entity.Dto.Exam;
using Entity.Dto.Question;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction.Service.Question
{
    public interface IQuestionService
    {
        List<QuestionDto> GetQuestionsByExamId(int id);
        List<QuestionDto> GetQuestions();

        QuestionDto GetQuestionById(int id);

        Task Create(QuestionDto questionDto);

        Task Update(QuestionDto questionDto);

        Task Delete(QuestionDto questionDto);
    }
}
