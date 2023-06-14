using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto.ApplicationUser
{
	public class ApplicationUserDto
	{
		public string? FirstName { get; set; }

		public string? LastName { get; set; }

		public string? IdentityNumber { get; set; }

		public string? Gender { get; set; }

		public string? RoleId { get; set; }

		public string? IsVerify { get; set; }

		public Guid? InsertedUser { get; set; }
		public DateTime InsertedDate { get; set; }

		public string? UpdatedUser { get; set; }

		public DateTime? UpdatedDate { get; set; }

		public string IsActive { get; set; }
	}
}
