using Entity.Domain.BaseEntity;

namespace UI.Models.Course
{
	public class CourseViewModel:BaseEntity
	{
		public string? Name { get; set; }
		public string? ErrorMessage { get; set; }
	}
}
