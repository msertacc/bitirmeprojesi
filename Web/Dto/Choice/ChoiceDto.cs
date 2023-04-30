namespace Entity.Dto.Choice
{
    public class ChoiceDto : BaseEntityDto.BaseEntityDto
    {
        public int? QuestionId { get; set; }
        public Question.QuestionDto Question { get; set; }
        public virtual string? ChoiceExplanation { get; set; }
        public bool? IsTrue { get; set; }
        public string[] AnswerArray { get; set; }
        public int? TrueAnswer { get; set; }
    }
}
