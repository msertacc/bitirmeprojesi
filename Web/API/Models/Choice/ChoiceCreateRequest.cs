namespace API.Models.Choice
{
    public class ChoiceCreateRequest
    {
        public int Id { get; set; }
        public int? QuestionId { get; set; }
        public string? ChoiceExplanation { get; }
        public bool? IsTrue { get; set; }
        public string[] AnswerArray { get; set; }
        public int? TrueAnswer { get; set; }
    }
}
