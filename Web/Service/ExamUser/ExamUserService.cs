using Abstraction.Service.ExamUser;
using Abstraction.Service.Shared;
using AutoMapper;
using DataAccess.Data;
using Entity.Dto.Course;
using Entity.Dto.ExamUser;
using Entity.Dto.StudentCourse;
using Microsoft.EntityFrameworkCore;

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
            var query = (from exams in context.Exams
                         join courses in context.Courses on exams.CourseId equals courses.Id
                         join examUser in context.ExamUsers on exams.Id equals examUser.ExamId into examUsers
                         from examUser in examUsers.DefaultIfEmpty()
                         join studentCourses in context.StudentCourses on courses.Id equals studentCourses.CourseId
                         where courses.IsActive == "1" && studentCourses.IsActive == "1" && exams.IsActive == "1" && studentCourses.UserId == Guid.Parse(id)
                         select new ExamUserDto
                         {
                             ExamId = exams.Id,
                             ExamName = exams.ExamName,
                             IsEnded = exams.IsEnded,
                             IsEndedByUser = examUser.IsEnded,
                             ExamStartTime = exams.ExamStartTime,
                             ExamEndTime = exams.ExamEndTime,
                             InsertedDate = exams.InsertedDate,
                             UpdatedDate = exams.UpdatedDate,
                         }).ToList();
            return query;
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

        public async Task Create(ExamUserDto examUserDto)
        {
            ArgumentNullException.ThrowIfNull(examUserDto);

            Entity.Domain.ExamUser.ExamUser examUser = new Entity.Domain.ExamUser.ExamUser();
            
            var data = DuplicateControl(examUserDto.ExamId, examUserDto.UserId);
            if (data)
            {
                return;
            }

            examUser.InsertedUser = "ExamService";
            examUser.IsActive = "1";
            examUser.InsertedDate = DateTime.Now;
            examUser.UserId = examUserDto.UserId;
            examUser.ExamId = examUserDto.ExamId;
            examUser.IsEnded = examUserDto.IsEnded;
            await context.Set<Entity.Domain.ExamUser.ExamUser>().AddAsync(examUser);
            await context.SaveChangesAsync();
        }

        public async Task Update(int? examId, Guid? userId)
        {
            var result = context.ExamUsers.AsNoTracking().Where(x => x.ExamId == examId && x.IsActive == "1" && x.UserId == userId).FirstOrDefault();
            var data = DuplicateControl(examId, userId);
            if (!data)
            {
                return;
            }
            result.IsEnded = "1";
            result.UpdatedDate = DateTime.Now;
            result.UpdatedUser = "ExamService";
            context.Set<Entity.Domain.ExamUser.ExamUser>().Update(result);
            await context.SaveChangesAsync();
        }

        public bool DuplicateControl(int? examId, Guid? userId)
        {
            var result = context.ExamUsers.AsNoTracking().Where(x => x.ExamId == examId && x.IsActive == "1" && x.UserId == userId).FirstOrDefault();
            if (result != null)
            {
                return true;
            }
            return false;
        }

    }
}
