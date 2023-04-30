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
                options.UseSqlServer("Server=LAPTOP-QORO4PVD;Database=SSA;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true");
            }
        }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}
		public DbSet<Entity.Domain.Course.Course> Courses { get; set; }
        public DbSet<Entity.Domain.Student.Student> Students { get; set; }
        public DbSet<Entity.Domain.Exam.Exam> Exams { get; set; }
        public DbSet<Entity.Domain.Choice.Choice> Choices { get; set; }
        public DbSet<Entity.Domain.Question.Question> Questions { get; set; }
        public DbSet<Entity.Domain.QuestionType.QuestionType> QuestionTypes { get; set; }
    }
}