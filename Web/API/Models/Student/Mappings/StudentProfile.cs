using AutoMapper;
using Entity.Dto.User;

namespace API.Models.User.Mappings
{
	public class UserProfile:Profile
	{
		public UserProfile()
		{
			this.CreateMap<UserCreateRequest, UserDto>();
			this.CreateMap<UserUpdateRequest, UserDto>();
		}
	}
}
