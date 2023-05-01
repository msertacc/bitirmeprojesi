namespace API.Models.Question
{
    public class QuestionCreateRequest
    {
        public int Id { get; set; }
        public string? QuestionText { get; set; }
        public int? QuestionTypeId { get; set; }
        public int? ExamId { get; set; }
        public int? Score { get; set; }
        public string[]? AnswerArray { get; set; }
        public int? TrueAnswer { get; set; }
    }
}
