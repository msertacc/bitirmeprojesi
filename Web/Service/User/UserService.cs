using Abstraction.Service.User;
using AutoMapper;
using DataAccess.Data;
using Entity.Domain.ApplicationUser;
using Entity.Dto.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Service.User
{
	public class UserService: IUserService
	{
		private ApplicationDbContext context;
		private IMapper mapper;
		private UserManager<ApplicationUser> _userManager;

		public UserService(ApplicationDbContext context, IMapper mapper, UserManager<ApplicationUser> userManager)
		{
			this.context = context;
			_userManager = userManager;
			this.mapper = mapper;
		}

		public List<ApplicationUser> GetUsers()
		{
			var result = context.Users.AsNoTracking().Where(x => x.IsActive == "1").ToList();
			return result;
		}

		public ApplicationUser GetUserById(Guid id)
		{
			var result = context.Users.AsNoTracking().Where(x => x.IsActive == "1" && x.Id == id.ToString()).FirstOrDefault();
			return result;
		}

		public async Task Create(UserDto userDto)
		{
			ArgumentNullException.ThrowIfNull(userDto);
			ArgumentNullException.ThrowIfNull(userDto.FirstName);
			ArgumentNullException.ThrowIfNull(userDto.LastName);
			ArgumentNullException.ThrowIfNull(userDto.IdentityNumber);
			ArgumentNullException.ThrowIfNull(userDto.PhoneNumber);
			ArgumentNullException.ThrowIfNull(userDto.EMail);
			ArgumentNullException.ThrowIfNull(userDto.Gender);
			ArgumentNullException.ThrowIfNull(userDto.Password);
			ArgumentNullException.ThrowIfNull(userDto.Role);

			var duplicateControl = this.DuplicateControl(userDto);
			if (duplicateControl == true)
			{
				throw new Exception("Bu kullanıcı daha önce kayıt edilmiş!");
			}

			userDto.InsertedDate = DateTime.Now;
			userDto.IsActive = "1";

			var isVerify = userDto.Role == "1" ? "0" : "1";

			ApplicationUser user = new ApplicationUser()
			{
				FirstName = userDto.FirstName,
				LastName = userDto.LastName,
				IdentityNumber = userDto.IdentityNumber,
				PhoneNumber = userDto.PhoneNumber,
				InsertedDate = DateTime.Now,
				InsertedUser = userDto.InsertedUser,
				IsActive = "1",
				RoleId = userDto.Role,
				AccessFailedCount = 0,
				IsVerify = isVerify,
				UserName = userDto.EMail,
				Email = userDto.EMail,
				EmailConfirmed = true,
				Gender = userDto.Gender,
				NormalizedUserName = userDto.EMail.ToUpper(),
				NormalizedEmail = userDto.EMail.ToUpper()
			};

			await _userManager.CreateAsync(user, userDto.Password);

			PasswordHasher<ApplicationUser> hasher = new PasswordHasher<ApplicationUser>();

			await context.Set<ApplicationUser>().AddAsync(user);

			var hashedPassword = hasher.HashPassword(user, userDto.Password);
			user.PasswordHash = hashedPassword;

			await context.SaveChangesAsync();
		}

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

		//public async Task Delete(int id)
		//{
		//	//ArgumentNullException.ThrowIfNull(id);

		//	//var user = this.GetUserById(id);
		//	//if (user == null)
		//	//{
		//	//	throw new Exception("Böyle bir kayıt bulunamadı!");
		//	//}

		//	//user.IsActive = "0";
		//	//user.UpdatedUser = Environment.UserName;
		//	//user.UpdatedDate = DateTime.Now;

		//	////var mappingResult = mapper.Map<UserDto, Entity.Domain.User.User>(user);
		//	//context.Set<Entity.Domain.User.User>().Update(mappingResult);
		//	//await context.SaveChangesAsync();

		//}
	}
}
