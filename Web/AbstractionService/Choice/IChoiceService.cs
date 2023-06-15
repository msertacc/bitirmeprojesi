using Entity.Dto.Choice;
using Entity.Dto.Course;
using Entity.Dto.Exam;
using Entity.Dto.Question;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction.Service.Choice
{
    public interface IChoiceService
    {
        List<ChoiceDto> GetChoiceByQuestionId(int id);
        List<ChoiceDto> GetChoicesByQuestionIdList(string questionIdList);       
    }
}
