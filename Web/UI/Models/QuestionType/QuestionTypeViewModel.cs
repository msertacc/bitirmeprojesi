using Entity.Domain.BaseEntity;

namespace UI.Models.QuestionType
{
    public class QuestionTypeViewModel : BaseEntity
    {
        public string? TypeName { get; set; }
        //	public List<Question.> Questions { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
