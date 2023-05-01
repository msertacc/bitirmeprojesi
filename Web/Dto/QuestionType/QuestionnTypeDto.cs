using Entity.Dto.BaseEntityDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.QuestionType
{
    public class QuestionTypeDto : BaseEntityDto.BaseEntityDto
    {
        public string TypeName { get; set; }
        //	public List<Question.QuestionDto> Questions { get; set; }
    }
}
