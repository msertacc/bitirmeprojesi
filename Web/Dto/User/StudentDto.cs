namespace Entity.Dto.User
{
	public class UserDto
	{
		public string? FirstName { get; set; }

		public string? LastName { get; set; }

		public string? IdentityNumber { get; set; }

		public string? PhoneNumber { get; set; }

		public string? EMail { get; set; }
		public string? Password { get; set; }
		public string? Gender { get; set; }
        public string? Role { get; set; }
        public string? IsVerify { get; set; }
		public string? IsActive { get; set; }
		public DateTime? InsertedDate { get; set; }
		public Guid? InsertedUser { get; set; }

	}
}
