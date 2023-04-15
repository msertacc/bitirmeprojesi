using AutoMapper;
using Entity.Dto.Course;

namespace API.Models.Course.Mappings
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
			this.CreateMap<CourseCreateRequest, CourseDto>();
			this.CreateMap<CourseUpdateRequest, CourseDto>();
		}
    }
}
