using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Domain.Exam
{
    [Table("Exam")]
    public class Exam : BaseEntity.BaseEntity
    {
        [Required]
        public virtual string? ExamName { get; set; }
        public virtual string? ExamDescription { get; set; }
        public DateTime? ExamStartTime { get; set; }
        public DateTime? ExamEndTime { get; set; }
        public int? ExamDuration { get; set; }
        public int? CourseId { get; set; }
        public Course.Course? Course { get; set; }
        public List<Question.Question>? Questions { get; set; }

    }
}
