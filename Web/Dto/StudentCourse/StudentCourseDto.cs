namespace Entity.Dto.StudentCourse
{
    public class StudentCourseDto : BaseEntityDto.BaseEntityDto
    {
        public Guid? UserId { get; set; }
        public int? CourseId { get; set; }
		public Course.CourseDto Course { get; set; }

	}
}
