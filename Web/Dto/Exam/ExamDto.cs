namespace Entity.Dto.Exam
{
    public class ExamDto : BaseEntityDto.BaseEntityDto
    {
        public string? ExamName { get; set; }
        public string? ExamDescription { get; set; }
        public DateTime? ExamStartTime { get; set; }
        public DateTime? ExamEndTime { get; set; }
        public int? ExamDuration { get; set; }
        public int? CourseId { get; set; }
        public Course.CourseDto Course { get; set; }
        public string? IsEnded { get; set; }
    }
}
