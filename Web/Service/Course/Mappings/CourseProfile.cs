using AutoMapper;
using Entity.Dto.Course;

namespace Service.Course.Mappings
{
	public class CourseProfile:Profile
    {
        public CourseProfile()
        {
            this.CreateMap<Entity.Domain.Course.Course, CourseDto>();
			this.CreateMap<CourseDto, Entity.Domain.Course.Course>();			
		}
    }
}
