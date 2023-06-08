using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Domain.Choice
{
    [Table("Choice")]
    public class Choice : BaseEntity.BaseEntity
    {
        [Required]
        public virtual string? ChoiceExplanation { get; set; }
        public bool? IsTrue { get; set; }
        public int? QuestionId { get; set; }
        public Question.Question Question { get; set; }
        public List<AnswerOfQuestion.AnswerOfQuestion> Answers { get; set; }
    }
}