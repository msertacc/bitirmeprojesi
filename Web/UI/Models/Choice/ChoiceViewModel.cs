using Entity.Domain.BaseEntity;

namespace UI.Models.Choice
{
    public class ChoiceViewModel : BaseEntity
    {
        public int? QuestionId { get; set; }
        public virtual string? ChoiceExplanation { get; set; }
        public bool? IsTrue { get; set; }
        public int? TrueAnswer { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
