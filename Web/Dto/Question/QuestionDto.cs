using Entity.Dto.BaseEntityDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.Question
{
    public class QuestionDto : BaseEntityDto.BaseEntityDto
    {
        public string QuestionText { get; set; }
        public int? ExamId { get; set; }
        public Exam.ExamDto Exam { get; set; }
        public int Score { get; set; }
        public string[] AnswerArray { get; set; }
        public int? TrueAnswer { get; set; }
    }
}
