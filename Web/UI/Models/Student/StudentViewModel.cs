using Entity.Domain.BaseEntity;

namespace UI.Models.User
{
	public class UserViewModel : BaseEntity
	{
		public Guid Id { get; set; }
		public string? FirstName { get; set; }

		public string? LastName { get; set; }

		public string? IdentityNumber { get; set; }

		public string? PhoneNumber { get; set; }

		public string? EMail { get; set; }

		public string? Gender { get; set; }
		public string? Role { get; set; }
		public string? Password { get; set; }
		public string? IsVerify { get; set; }

	}
}
