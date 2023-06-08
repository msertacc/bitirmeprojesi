namespace API.Models.AnswerOfQuestion
{
    public class AnswerOfQuestionCreateRequest
    {
        public List<AnswerRequest> AnswerList { get; set; }
        public int? ExamId { get; set; }
        public Guid? UserId { get; set; }
    }

    public class AnswerRequest
    {
        public int? ChoiceId { get; set; }
        public int? QuestionId { get; set; }
    }
}
