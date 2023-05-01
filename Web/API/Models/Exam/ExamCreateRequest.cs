namespace API.Models.Exam
{
    public class ExamCreateRequest
    {
        public int Id { get; set; }
        public string? ExamName { get; set; }
        public string? ExamDescription { get; set; }
        public DateTime? ExamStartTime { get; set; }
        public DateTime? ExamEndTime { get; set; }
        public int? ExamDuration { get; set; }
        public int? CourseId { get; set; }
    }
}
