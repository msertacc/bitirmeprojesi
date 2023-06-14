using Entity.Domain.BaseEntity;

namespace API.Models.UserCourse
{
    public class UserCourseCreateRequest
    {
		public Guid? UserId { get; set; }
		public int? CourseId { get; set; }
	}
}
