using Abstraction.Service.StudentCourse;
using AutoMapper;
using DataAccess.Data;
using Entity.Domain.Course;
using Entity.Domain.Question;
using Entity.Domain.StudentCourse;
using Entity.Dto.Choice;
using Entity.Dto.Course;
using Entity.Dto.StudentCourse;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.StudentCourse
{
    public class StudentCourseService:IStudentCourseService
    {
		private ApplicationDbContext context;
		private IMapper mapper;

		public StudentCourseService(ApplicationDbContext context, IMapper mapper)
		{
			this.context = context;
			this.mapper = mapper;
		}

		public async Task<StudentCourseDto> Create(StudentCourseDto studentCourseDto)
        {
			ArgumentNullException.ThrowIfNull(studentCourseDto);

			var duplicateControl = this.DuplicateControl(studentCourseDto);
			if (duplicateControl == true)
			{
				throw new Exception("Bu ders daha önce kayıt edilmiş!");
			}

			studentCourseDto.InsertedUser = Environment.UserName;
			studentCourseDto.InsertedDate = DateTime.Now;
			studentCourseDto.IsActive = "1";

			var mappingResult = mapper.Map<StudentCourseDto, Entity.Domain.StudentCourse.StudentCourse>(studentCourseDto);

			await context.Set<Entity.Domain.StudentCourse.StudentCourse>().AddAsync(mappingResult);
			await context.SaveChangesAsync();

			return studentCourseDto;
		}

        public async Task Delete(int id)
        {
			
			ArgumentNullException.ThrowIfNull(id);

			var data = this.GetStudentCourseById(id);
			if (data == null)
			{
				throw new Exception("Böyle bir kayıt bulunamadı!");
			}

			data.IsActive = "0";
			data.UpdatedUser = Environment.UserName;
			data.UpdatedDate = DateTime.Now;

			var mappingResult = mapper.Map<StudentCourseDto, Entity.Domain.StudentCourse.StudentCourse>(data);
			context.Set<Entity.Domain.StudentCourse.StudentCourse>().Update(mappingResult);
			await context.SaveChangesAsync();
		}

		public List<StudentCourseDto> GetStudentCourse(Guid userId)
        {
			var result = context.StudentCourses.AsNoTracking().Include(i => i.Course).Where(x => x.CourseId == x.Course.Id && x.IsActive == "1" && x.UserId == userId).ToList();
			var mappingResult = mapper.Map<List<StudentCourseDto>>(result);
			return mappingResult;
		}

        public StudentCourseDto GetStudentCourseById(int id)
        {
			var result = context.StudentCourses.AsNoTracking().Where(x => x.IsActive == "1" && x.Id == id).FirstOrDefault();
			var mappingResult = mapper.Map<StudentCourseDto>(result);
			return mappingResult;
		}

        public Task Update(StudentCourseDto studentCourseDto)
        {
            throw new NotImplementedException();
        }

		public bool DuplicateControl(StudentCourseDto studentCourseDto)
		{
			var result = context.StudentCourses.AsNoTracking().Where(x => x.IsActive == "1" && x.UserId == studentCourseDto.UserId && x.CourseId==studentCourseDto.CourseId).FirstOrDefault();
			if (result != null)
			{
				return true;
			}
			return false;
		}
	}
}
