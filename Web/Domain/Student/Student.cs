﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Domain.Student
{
	[Table("Student")]
	public class Student:BaseEntity.BaseEntity
	{
		[Required]
		[StringLength(50)]
		public string? FirstName { get; set; }

		[Required]
		[StringLength(50)]
		public string? LastName { get; set; }

		[Required]
		[StringLength(11)]
		public string? IdentityNumber { get; set; }

		[Required]
		public string? PhoneNumber { get; set; }

		[Required]
		public string? EMail { get; set; }

		[Required]
		public string? Gender { get; set; }
	}
}
