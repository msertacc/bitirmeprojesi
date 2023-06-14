using Entity.Domain.BaseEntity;

namespace UI.Models.Exam
{
    public class ExamViewModel : BaseEntity
    {
        public string? ExamName { get; set; }
        public string? ExamDescription { get; set; }
        public DateTime? ExamStartTime { get; set; }
        public DateTime? ExamEndTime { get; set; }
        public int? CourseId { get; set; }
        public Entity.Domain.Course.Course? Course { get; set; }
        public List<Entity.Domain.Question.Question>? Questions { get; set; }
        public string? ErrorMessage { get; set; }
        public string? IsEnded { get; set; }
		public string? CourseName { get; set; }

	}
}
