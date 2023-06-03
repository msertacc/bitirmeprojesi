using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Domain.Question
{
    [Table("Question")]
    public class Question : BaseEntity.BaseEntity
    {
        public virtual string QuestionText { get; set; }
        public int? ExamId { get; set; }
        public Exam.Exam Exam { get; set; }
        public int? Score { get; set; }
        public List<Choice.Choice> Choices { get; set; }
    }
}
