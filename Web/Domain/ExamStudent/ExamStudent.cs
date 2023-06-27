using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Entity.Domain.ExamUser
{

    [Table("ExamUser")]
    public class ExamUser:BaseEntity.BaseEntity
    {
        public int Id { get; set; }
        public int ExamId { get; set; }
        public Guid UserId { get; set; }
        public string IsEnded { get; set; }
		public List<StudentCourse.StudentCourse>? StudentCourses { get; set; }

	}

	[Table("Exam")]
    public class Exam : BaseEntity.BaseEntity
    {
        public string? ExamName { get; set; }
        public string? ExamDescription { get; set; }
        public DateTime? ExamStartTime { get; set; }
        public DateTime? ExamEndTime { get; set; }
        public int? CourseId { get; set; }
        public string? IsEnded { get; set; }
    }
}
