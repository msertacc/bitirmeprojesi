using Abstraction.Service.Student;
using AutoMapper;
using DataAccess.Data;
using Entity.Dto.Student;
using Microsoft.EntityFrameworkCore;

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

		public StudentDto GetStudentById(int id)
		{
			var result = context.Students.AsNoTracking().Where(x => x.IsActive == "1" && x.Id == id).FirstOrDefault();
			var mappingResult = mapper.Map<StudentDto>(result);
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

		public async Task Update(StudentDto studentDto)
		{
			ArgumentNullException.ThrowIfNull(studentDto);
			ArgumentNullException.ThrowIfNull(studentDto.FirstName);
			ArgumentNullException.ThrowIfNull(studentDto.LastName);
			ArgumentNullException.ThrowIfNull(studentDto.IdentityNumber);
			ArgumentNullException.ThrowIfNull(studentDto.PhoneNumber);
			ArgumentNullException.ThrowIfNull(studentDto.EMail);
			ArgumentNullException.ThrowIfNull(studentDto.Gender);

			var student = this.GetStudentById(studentDto.Id);

			if (student == null)
			{
				throw new Exception("Böyle bir kayıt bulunamadı!");
			}

			student.FirstName = studentDto.FirstName;
			student.LastName = studentDto.LastName;
			student.IdentityNumber = studentDto.IdentityNumber;
			student.PhoneNumber = studentDto.PhoneNumber;
			student.EMail = studentDto.EMail;
			student.Gender = studentDto.Gender;
			student.UpdatedUser = Environment.UserName;
			student.UpdatedDate = DateTime.Now;

			var duplicateControl = this.DuplicateControl(student);
			if (duplicateControl == true)
			{
				throw new Exception("Bu öğrenci daha önce kayıt edilmiş!");
			}

			var mappingResult = mapper.Map<StudentDto, Entity.Domain.Student.Student>(student);

			context.Set<Entity.Domain.Student.Student>().Update(mappingResult);
			await context.SaveChangesAsync();
		}

		public async Task Delete(int id)
		{
			ArgumentNullException.ThrowIfNull(id);

			var student = this.GetStudentById(id);
			if (student == null)
			{
				throw new Exception("Böyle bir kayıt bulunamadı!");
			}

			student.IsActive = "0";
			student.UpdatedUser = Environment.UserName;
			student.UpdatedDate = DateTime.Now;

			var mappingResult = mapper.Map<StudentDto, Entity.Domain.Student.Student>(student);
			context.Set<Entity.Domain.Student.Student>().Update(mappingResult);
			await context.SaveChangesAsync();

		}

		public bool DuplicateControl(StudentDto studentDto)
		{
			var result = context.Students.AsNoTracking().Where(x => x.IsActive == "1" && x.IdentityNumber==studentDto.IdentityNumber && x.EMail==studentDto.EMail).FirstOrDefault();
			if (result != null)
			{
				return true;
			}
			return false;
		}

	}
}
