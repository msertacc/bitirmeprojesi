using Entity.Dto.Course;

namespace Abstraction.Service.Course
{
	public interface ICourseService
    {
        List<CourseDto> GetCourses();

        CourseDto GetCourseById(int id);

        Task Create(CourseDto courseDto);

        Task Update(CourseDto courseDto);

        Task Delete(int id);
    }
}
