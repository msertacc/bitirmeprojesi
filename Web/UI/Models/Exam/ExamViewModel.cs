using Entity.Domain.BaseEntity;
using System.ComponentModel.DataAnnotations;

namespace UI.Models.Exam
{
    public class ExamViewModel : BaseEntity
    {
        //[Required]
        public string? ExamName { get; set; }
        //[Required]
        public string? ExamDescription { get; set; }
        //[Required]
        public DateTime? ExamStartTime { get; set; }
        //[Required]
        public DateTime? ExamEndTime { get; set; }
        //[Required]
        public int? ExamDuration { get; set; }
        //[Required]
        public int? CourseId { get; set; }
        public Entity.Domain.Course.Course? Course { get; set; }
        public List<Entity.Domain.Question.Question>? Questions { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
