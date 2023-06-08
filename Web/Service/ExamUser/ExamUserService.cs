using Abstraction.Service.ExamUser;
using AutoMapper;
using DataAccess.Data;
using Entity.Dto.ExamUser;
using Microsoft.EntityFrameworkCore;
using Abstraction.Service.Shared;

namespace Service.ExamUser
{
    public class ExamUserService : IExamUserService
    {
        private ApplicationDbContext context;
        private IMapper mapper;

        public ExamUserService(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public List<ExamUserDto> GetExamByUser(string id)
        {
            var result = context.ExamUsers.AsNoTracking().Where(x => x.IsActive == "1" && x.UserId == id).ToList();
            var mappingResult = mapper.Map<List<ExamUserDto>>(result);
            return mappingResult;
        }

        public IEnumerable<ResultExamDto> GetResultsForExams(Guid userid)
        {
            var result = context.Questions
            .Join(context.Choices, q => q.Id, c => c.QuestionId, (q, c) => new { Question = q, Choice = c })
            .Join(context.AnswerOfQuestions, qc => qc.Choice.Id, a => a.ChoiceId, (qc, a) => new { QuestionChoice = qc, Answer = a })
            .Where(x => x.QuestionChoice.Choice.IsActive == "1" && x.QuestionChoice.Question.IsActive == "1" && x.Answer.Choice.IsTrue == true && x.Answer.UserId == userid)
            .GroupBy(x => x.QuestionChoice.Question.ExamId)
            .Select(g => new ResultExamDto
            {
                ExamEndTime = Provider.DateTimeFormatter(context.Exams.FirstOrDefault(e => e.Id == g.Key).ExamEndTime.Value.Minute, context.Exams.FirstOrDefault(e => e.Id == g.Key).ExamEndTime.Value.Hour, context.Exams.FirstOrDefault(e => e.Id == g.Key).ExamEndTime.Value.Day, context.Exams.FirstOrDefault(e => e.Id == g.Key).ExamEndTime.Value.Month, context.Exams.FirstOrDefault(e => e.Id == g.Key).ExamEndTime.Value.Year),
				ExamStartTime = Provider.DateTimeFormatter(context.Exams.FirstOrDefault(e => e.Id == g.Key).ExamStartTime.Value.Minute, context.Exams.FirstOrDefault(e => e.Id == g.Key).ExamStartTime.Value.Hour, context.Exams.FirstOrDefault(e => e.Id == g.Key).ExamStartTime.Value.Day, context.Exams.FirstOrDefault(e => e.Id == g.Key).ExamStartTime.Value.Month, context.Exams.FirstOrDefault(e => e.Id == g.Key).ExamStartTime.Value.Year),
				CourseName = context.Exams.FirstOrDefault(e => e.Id == g.Key).Course.Name,
				ExamName = context.Exams.FirstOrDefault(e => e.Id == g.Key).ExamName,
                Score = g.Sum(x => x.QuestionChoice.Question.Score)
            }).AsEnumerable();

            return result;
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
