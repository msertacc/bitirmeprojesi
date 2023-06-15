using Entity.Dto.Course;

namespace Abstraction.Service.Course
{
	public interface ICourseService
    {
        List<CourseDto> GetCourses();

        List<CourseDto> GetCoursesByGuid(Guid id);

        CourseDto GetCourseById(int id);

        Task<CourseDto> Create(CourseDto courseDto);

        Task Update(CourseDto courseDto);

        Task Delete(int id);
    }
}
