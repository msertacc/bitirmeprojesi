using AutoMapper;
using Microsoft.EntityFrameworkCore;
using DataAccess.Data;
using Entity.Dto.Course;
using Abstraction.Service.ExamStudent;
using Entity.Dto.ExamStudent;

namespace Service.ExamStudent
{
	public class ExamStudentService : IExamStudentService
    {
        private ApplicationDbContext context;
        private IMapper mapper;

        public ExamStudentService(ApplicationDbContext context,IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

		public List<ExamStudentDto> GetExamByStudent(int userId)
        {
            var result = context.ExamStudents.AsNoTracking().Where(x => x.IsActive == "1" && x.StudentId == userId).ToList();
            var mappingResult=mapper.Map<List<ExamStudentDto>>(result);
            return mappingResult;
        }

		//public CourseDto GetCourseById(int id)
		//{
		//	var result = context.Courses.AsNoTracking().Where(x => x.IsActive == "1" && x.Id==id).FirstOrDefault();
		//	var mappingResult = mapper.Map<CourseDto>(result);
		//	return mappingResult;
		//}

		//public async Task<CourseDto> Create(CourseDto courseDto)
		//{
  //          ArgumentNullException.ThrowIfNull(courseDto);
  //          ArgumentNullException.ThrowIfNull(courseDto.Name);

  //          var duplicateControl=this.DuplicateControl(courseDto);
  //          if(duplicateControl == true)
  //          {
  //              throw new Exception("Bu ders daha önce kayıt edilmiş!");
  //          }

		//	courseDto.InsertedUser=Environment.UserName;
  //          courseDto.InsertedDate=DateTime.Now;
  //          courseDto.IsActive = "1";

  //          var mappingResult = mapper.Map<CourseDto,Entity.Domain.Course.Course>(courseDto);

  //          await context.Set<Entity.Domain.Course.Course>().AddAsync(mappingResult);
  //          await context.SaveChangesAsync();

		//	return courseDto;

		//}

		//public async Task Update(CourseDto courseDto)
		//{
		//	ArgumentNullException.ThrowIfNull(courseDto);
		//	ArgumentNullException.ThrowIfNull(courseDto.Id);
		//	ArgumentNullException.ThrowIfNull(courseDto.Name);

		//	var course=this.GetCourseById(courseDto.Id);

		//	if(course == null)
		//	{
		//		throw new Exception("Böyle bir kayıt bulunamadı!");
		//	}

		//	course.Name=courseDto.Name;
		//	course.UpdatedUser=Environment.UserName;
		//	course.UpdatedDate=DateTime.Now;

		//	var duplicateControl = this.DuplicateControl(course);
		//	if (duplicateControl == true)
		//	{
		//		throw new Exception("Bu ders daha önce kayıt edilmiş!");
		//	}

		//	var mappingResult = mapper.Map<CourseDto, Entity.Domain.Course.Course>(course);

		//	context.Set<Entity.Domain.Course.Course>().Update(mappingResult);
		//	await context.SaveChangesAsync();

		//}

		//public async Task Delete(int id)
		//{
		//	ArgumentNullException.ThrowIfNull(id);

		//	var course = this.GetCourseById(id);
		//	if (course == null)
		//	{
		//		throw new Exception("Böyle bir kayıt bulunamadı!");
		//	}

		//	course.IsActive = "0";
		//	course.UpdatedUser = Environment.UserName;
		//	course.UpdatedDate = DateTime.Now;

		//	var mappingResult = mapper.Map<CourseDto, Entity.Domain.Course.Course>(course);
		//	context.Set<Entity.Domain.Course.Course>().Update(mappingResult);
		//	await context.SaveChangesAsync();

		//}

		//public bool DuplicateControl(CourseDto courseDto)
  //      {
		//	var result = context.Courses.AsNoTracking().Where(x => x.IsActive == "1" && x.Name.Trim().ToLower()==courseDto.Name.Trim().ToLower()).FirstOrDefault();
  //          if(result!=null)
  //          {
  //              return true;
  //          }
  //          return false;
		//}		
	}
}
