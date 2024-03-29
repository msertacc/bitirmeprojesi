﻿namespace API.Models.User
{
	public class UserCreateRequest
	{
		public string? FirstName { get; set; }

		public string? LastName { get; set; }
		public string? InsertedUser { get; set; }

		public string? IdentityNumber { get; set; }

		public string? PhoneNumber { get; set; }

		public string? EMail { get; set; }

		public string? Gender { get; set; }
		public string? Role { get; set; }
		public string? Password { get; set; }
	}
}
