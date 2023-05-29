using AutoMapper;
using Entity.Dto.User;

namespace Service.User.Mappings
{
	public class UserProfile:Profile
	{
		public UserProfile()
		{
			this.CreateMap<Entity.Domain.User.User, UserDto>();
			this.CreateMap<UserDto,	Entity.Domain.User.User>();
		}
	}
}
