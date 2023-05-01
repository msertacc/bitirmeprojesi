using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Domain.QuestionType
{
    [Table("QuestionType")]
    public class QuestionType : BaseEntity.BaseEntity
    {
        public virtual string TypeName { get; set; }
        public List<Question.Question> Questions { get; set; }
    }
}
