using API.Models.User;
using AutoMapper;
using Entity.Dto.StudentCourse;
using Entity.Dto.User;

namespace API.Models.UserCourse.Mappings
{
	public class UserCourseProfile:Profile
	{
		public UserCourseProfile()
		{
			this.CreateMap<UserCourseCreateRequest, StudentCourseDto>();
		}
	}
}
