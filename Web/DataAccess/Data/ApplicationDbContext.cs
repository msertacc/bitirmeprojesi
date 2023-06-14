using Entity.Domain.ApplicationUser;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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
				options.UseSqlServer("Server=LAPTOP-QORO4PVD;Database=SSA;User Id=sa; Password=12;Integrated Security=SSPI;TrustServerCertificate=True");
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<ApplicationUser>()
				.Ignore(x => x.AccessFailedCount)
				.Ignore(x => x.ConcurrencyStamp)
				.Ignore(x => x.EmailConfirmed)
				.Ignore(x => x.LockoutEnabled)
				.Ignore(x => x.LockoutEnd)
				.Ignore(x => x.NormalizedEmail)
				.Ignore(x => x.NormalizedUserName)
				.Ignore(x => x.TwoFactorEnabled)
				.Ignore(x => x.PhoneNumberConfirmed)
				.Ignore(x => x.SecurityStamp);
				//.Ignore(x => x.InsertedUserName);
			base.OnModelCreating(modelBuilder);
		}
		public DbSet<Entity.Domain.Course.Course> Courses { get; set; }
        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<Entity.Domain.ExamUser.ExamUser> ExamUsers { get; set; }
        public DbSet<Entity.Domain.Exam.Exam> Exams { get; set; }
        public DbSet<Entity.Domain.Choice.Choice> Choices { get; set; }
        public DbSet<Entity.Domain.Question.Question> Questions { get; set; }
        public DbSet<Entity.Domain.AnswerOfQuestion.AnswerOfQuestion> AnswerOfQuestions { get; set; }
		public DbSet<Entity.Domain.StudentCourse.StudentCourse> StudentCourses { get; set; }

	}
}