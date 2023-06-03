using Entity.Domain.ApplicationUser;
using Entity.Dto.User;

namespace Abstraction.Service.User
{
	public interface IUserService
	{
		List<ApplicationUser> GetUsers();

        ApplicationUser GetUserById(int id);

        Task<ApplicationUser> UpdateVerify(Guid id);

        //Task Create(UserDto userDto);

        //Task Update(UserDto userDto);

        //Task Delete(int id);
    }
}
