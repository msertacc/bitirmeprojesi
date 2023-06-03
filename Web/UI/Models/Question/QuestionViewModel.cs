using Entity.Domain.BaseEntity;

namespace UI.Models.Question
{
    public class QuestionViewModel : BaseEntity
    {
        public string? QuestionText { get; set; }
        public int? ExamId { get; set; }
        public Entity.Domain.Exam.Exam? Exam { get; set; }
        public int? Score { get; set; }
        public string[]? AnswerArray { get; set; }
        public int? TrueAnswer { get; set; }
        public string? ErrorMessage { get; set; }


    }
}
