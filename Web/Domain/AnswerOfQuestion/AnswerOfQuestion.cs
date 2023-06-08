using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Domain.AnswerOfQuestion
{
    [Table("AnswerOfQuestion")]
    public class AnswerOfQuestion : BaseEntity.BaseEntity
    {
        public Guid? UserId { get; set; }
        public int? ExamId { get; set; }
        public int? QuestionId { get; set; }
        public int? ChoiceId { get; set; }
        public Choice.Choice? Choice { get; set; }
    }
}
