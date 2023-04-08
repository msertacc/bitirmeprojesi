using AutoMapper;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Abstraction.Service.Student;
using Entity.Dto.Student;

namespace Service.Student
{
	public class StudentService:IStudentService
	{
		private ApplicationDbContext context;
		private IMapper mapper;

		public StudentService(ApplicationDbContext context, IMapper mapper)
		{
			this.context = context;
			this.mapper = mapper;
		}


		public List<StudentDto> GetStudents()
		{
			var result = context.Students.AsNoTracking().Where(x => x.IsActive == "1").ToList();
			var mappingResult = mapper.Map<List<StudentDto>>(result);
			return mappingResult;
		}

		public async Task Create(StudentDto studentDto)
		{
			ArgumentNullException.ThrowIfNull(studentDto);
			ArgumentNullException.ThrowIfNull(studentDto.FirstName);
			ArgumentNullException.ThrowIfNull(studentDto.LastName);
			ArgumentNullException.ThrowIfNull(studentDto.IdentityNumber);
			ArgumentNullException.ThrowIfNull(studentDto.PhoneNumber);
			ArgumentNullException.ThrowIfNull(studentDto.EMail);
			ArgumentNullException.ThrowIfNull(studentDto.Gender);

			var duplicateControl = this.DuplicateControl(studentDto);
			if (duplicateControl == true)
			{
				throw new Exception("Bu öğrenci daha önce kayıt edilmiş!");
			}

			studentDto.InsertedUser = Environment.UserName;
			studentDto.InsertedDate = DateTime.Now;
			studentDto.IsActive = "1";

			var mappingResult = mapper.Map<StudentDto,Entity.Domain.Student.Student>(studentDto);

			await context.Set<Entity.Domain.Student.Student>().AddAsync(mappingResult);
			await context.SaveChangesAsync();
		}

		public bool DuplicateControl(StudentDto studentDto)
		{
			var result = context.Students.AsNoTracking().Where(x => x.IsActive == "1" && x.IdentityNumber==studentDto.IdentityNumber).FirstOrDefault();
			if (result != null)
			{
				return true;
			}
			return false;
		}
	}
}
