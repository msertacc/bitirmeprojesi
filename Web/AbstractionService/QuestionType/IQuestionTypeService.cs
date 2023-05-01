using Entity.Dto.Exam;
using Entity.Dto.QuestionType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction.Service.QuestionType
{
    public interface IQuestionTypeService
    {
        List<QuestionTypeDto> GetQuestionType();

        QuestionTypeDto GetQuestionTypeId(int id);

        Task Create(QuestionTypeDto questionTypeDto);

        Task Update(QuestionTypeDto questionTypeDto);

        Task Delete(QuestionTypeDto questionTypeDto);
    }
}
