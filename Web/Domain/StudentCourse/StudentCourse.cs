using Entity.Domain.BaseEntity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Domain.StudentCourse
{
    [Table("StudentCourse")]
    public class StudentCourse : BaseEntity.BaseEntity
    {
        public Guid UserId { get; set; }
        public int? CourseId { get; set; }
		public Course.Course? Course { get; set; }
	}
}
