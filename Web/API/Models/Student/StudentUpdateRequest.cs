namespace API.Models.User
{
	public class UserUpdateRequest
	{
        public Guid Id { get; set; }

        public string? FirstName { get; set; }

		public string? LastName { get; set; }

		public string? IdentityNumber { get; set; }

		public string? PhoneNumber { get; set; }

		public string? EMail { get; set; }

	}
}
