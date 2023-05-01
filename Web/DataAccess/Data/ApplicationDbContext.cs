﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Data
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
		public ApplicationDbContext()
		{
		}

		protected override void OnConfiguring(DbContextOptionsBuilder options)
		{
			if (!options.IsConfigured)
			{
				options.UseSqlServer("Server=DESKTOP-0IL4JB7;Database=SSA;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true");
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}
		public DbSet<Entity.Domain.Course.Course> Courses { get; set; }
        public DbSet<Entity.Domain.Student.Student> Students { get; set; }
        public DbSet<Entity.Domain.ExamStudent.ExamStudent> ExamStudents { get; set; }
    }
}