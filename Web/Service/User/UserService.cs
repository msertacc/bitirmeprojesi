using Abstraction.Service.User;
using AutoMapper;
using DataAccess.Data;
using Entity.Domain.ApplicationUser;
using Entity.Dto.User;
using Microsoft.EntityFrameworkCore;

namespace Service.User
{
	public class UserService: IUserService
	{
		private ApplicationDbContext context;
		private IMapper mapper;

		public UserService(ApplicationDbContext context, IMapper mapper)
		{
			this.context = context;
			this.mapper = mapper;
		}

		public List<ApplicationUser> GetUsers()
		{
			var result = context.Users.AsNoTracking().Where(x => x.IsActive == "1").ToList();
			//var mappingResult = mapper.Map<List<UserDto>>(result);
			return result;
		}

		public ApplicationUser GetUserById(Guid id)
		{
			var result = context.Users.AsNoTracking().Where(x => x.IsActive == "1" && x.Id == id.ToString()).FirstOrDefault();
			//var mappingResult = mapper.Map<UserDto>(result);
			return result;
		}

		//public async Task Create(UserDto userDto)
		//{
		//	ArgumentNullException.ThrowIfNull(userDto);
		//	ArgumentNullException.ThrowIfNull(userDto.FirstName);
		//	ArgumentNullException.ThrowIfNull(userDto.LastName);
		//	ArgumentNullException.ThrowIfNull(userDto.IdentityNumber);
		//	ArgumentNullException.ThrowIfNull(userDto.PhoneNumber);
		//	ArgumentNullException.ThrowIfNull(userDto.EMail);
		//	ArgumentNullException.ThrowIfNull(userDto.Gender);

		//	var duplicateControl = this.DuplicateControl(userDto);
		//	if (duplicateControl == true)
		//	{
		//		throw new Exception("Bu öğrenci daha önce kayıt edilmiş!");
		//	}

		//	//userDto.InsertedUser = Environment.UserName;
		//	//userDto.InsertedDate = DateTime.Now;
		//	//userDto.IsActive = "1";

		//	//var mappingResult = mapper.Map<UserDto,Entity.Domain.User.User>(userDto);

		//	//await context.Set<Entity.Domain.User.User>().AddAsync(mappingResult);
		//	await context.SaveChangesAsync();
		//}

		//public async Task Update(UserDto userDto)
		//{
		//	ArgumentNullException.ThrowIfNull(userDto);
		//	ArgumentNullException.ThrowIfNull(userDto.FirstName);
		//	ArgumentNullException.ThrowIfNull(userDto.LastName);
		//	ArgumentNullException.ThrowIfNull(userDto.IdentityNumber);
		//	ArgumentNullException.ThrowIfNull(userDto.PhoneNumber);
		//	ArgumentNullException.ThrowIfNull(userDto.EMail);
		//	ArgumentNullException.ThrowIfNull(userDto.Gender);

		//	//var user = this.GetUserById(userDto.Id);

		//	if (user == null)
		//	{
		//		throw new Exception("Böyle bir kayıt bulunamadı!");
		//	}

		//	user.FirstName = userDto.FirstName;
		//	user.LastName = userDto.LastName;
		//	user.IdentityNumber = userDto.IdentityNumber;
		//	user.PhoneNumber = userDto.PhoneNumber;
		//	user.EMail = userDto.EMail;
		//	user.Gender = userDto.Gender;
		//	user.UpdatedUser = Environment.UserName;
		//	user.UpdatedDate = DateTime.Now;

		//	var duplicateControl = this.DuplicateControl(user);
		//	if (duplicateControl == true)
		//	{
		//		throw new Exception("Bu öğrenci daha önce kayıt edilmiş!");
		//	}

		//	//var mappingResult = mapper.Map<UserDto, Entity.Domain.User.User>(user);

		//	context.Set<Entity.Domain.User.User>().Update(mappingResult);
		//	await context.SaveChangesAsync();
		//}

		//public async Task Delete(int id)
		//{
		//	ArgumentNullException.ThrowIfNull(id);

		//	var user = this.GetUserById(id);
		//	if (user == null)
		//	{
		//		throw new Exception("Böyle bir kayıt bulunamadı!");
		//	}

		//	user.IsActive = "0";
		//	user.UpdatedUser = Environment.UserName;
  //          user.UpdatedDate = DateTime.Now;

		//	//var mappingResult = mapper.Map<UserDto, Entity.Domain.User.User>(user);
		//	context.Set<Entity.Domain.User.User>().Update(mappingResult);
		//	await context.SaveChangesAsync();

		//}

		public bool DuplicateControl(UserDto UserDto)
		{
			var result = context.Users.AsNoTracking().Where(x => x.IsActive == "1" && x.IdentityNumber==UserDto.IdentityNumber && x.Email==UserDto.EMail).FirstOrDefault();
			if (result != null)
			{
				return true;
			}
			return false;
		}

        public async Task<ApplicationUser> UpdateVerify(Guid id)
        {
			var user = this.GetUserById(id);

			if (user == null)
			{
				throw new Exception("Böyle bir kayıt bulunamadı!");
			}
			user.UpdatedDate = DateTime.Now;
			user.IsVerify = "1";
			
			context.Set<ApplicationUser>().Update(user);
			await context.SaveChangesAsync();

			return user;
		}

		public async Task Delete(int id)
		{
			//ArgumentNullException.ThrowIfNull(id);

			//var user = this.GetUserById(id);
			//if (user == null)
			//{
			//	throw new Exception("Böyle bir kayıt bulunamadı!");
			//}

			//user.IsActive = "0";
			//user.UpdatedUser = Environment.UserName;
			//user.UpdatedDate = DateTime.Now;

			////var mappingResult = mapper.Map<UserDto, Entity.Domain.User.User>(user);
			//context.Set<Entity.Domain.User.User>().Update(mappingResult);
			//await context.SaveChangesAsync();

		}

        public ApplicationUser GetUserById(int id)
        {
            throw new NotImplementedException();
        }

    }
}
