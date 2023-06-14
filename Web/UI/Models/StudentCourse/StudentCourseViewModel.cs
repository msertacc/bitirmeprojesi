using Entity.Domain.ApplicationUser;
using Entity.Domain.BaseEntity;
using UI.Models.Course;

namespace UI.Models.StudentCourse
{
    public class StudentCourseViewModel
    {
        public List<CourseViewModel>CourseList { get; set; }
		public List<UsersCourseModel> UsersCourseList { get; set; }
		public ApplicationUser UserInfo { get; set; }

	}

	public class UsersCourseModel : BaseEntity
	{
		public Guid UserId { get; set; }
		public int? CourseId { get; set; }
		public Course.CourseViewModel Course { get; set; }

	}
}
