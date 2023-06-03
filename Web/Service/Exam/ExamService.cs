using Abstraction.Service.Exam;
using AutoMapper;
using DataAccess.Data;
using Entity.Domain.Question;
using Entity.Dto.Choice;
using Entity.Dto.Course;
using Entity.Dto.Exam;
using Entity.Dto.Question;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Linq;

namespace Service.Exam
{
    public class ExamService : IExamService
    {
        private ApplicationDbContext context;
        private IMapper mapper;

        public ExamService(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task Create(ExamDto examDto)
        {
            ArgumentNullException.ThrowIfNull(examDto);
            ArgumentNullException.ThrowIfNull(examDto.ExamName);

            examDto.InsertedUser = Environment.UserName;
            examDto.InsertedDate = DateTime.Now;
            examDto.IsActive = "1";
            examDto.IsEnded = "1";
            var mappingResult = mapper.Map<ExamDto, Entity.Domain.Exam.Exam>(examDto);

            await context.Set<Entity.Domain.Exam.Exam>().AddAsync(mappingResult);
            await context.SaveChangesAsync();
        }

        public async Task Delete(ExamDto examDto)
        {
            ArgumentNullException.ThrowIfNull(examDto.Id);

            var exam = this.GetExamById(examDto.Id);
            if (exam == null)
            {
                throw new Exception("Böyle bir kayıt bulunamadı!");
            }

            exam.IsActive = "0";
            exam.UpdatedUser = Environment.UserName;
            exam.UpdatedDate = DateTime.Now;

            var mappingResult = mapper.Map<ExamDto, Entity.Domain.Exam.Exam>(exam);
            context.Set<Entity.Domain.Exam.Exam>().Update(mappingResult);
            await context.SaveChangesAsync();

			//sınava ait sorular silinir.

			List<QuestionDto> questionList = new List<QuestionDto>();
			questionList = GetQuestionByExamId(examDto.Id);

			for (int i = 0; i < questionList.Count; i++)
			{

				var questionItem = new Entity.Domain.Question.Question
				{
					UpdatedUser = Environment.UserName,
					UpdatedDate = DateTime.Now,
					IsActive = "0",
					InsertedUser = questionList[i].InsertedUser,
					InsertedDate = questionList[i].InsertedDate,
					Id = questionList[i].Id,
					QuestionText= questionList[i].QuestionText,
					ExamId = questionList[i].ExamId,
					Score = questionList[i].Score,
				};
				if (questionItem != null)
				{
					context.Questions.Update(questionItem);
				}

				//soruya ait seçenekler silinir.

				List<ChoiceDto> choiceList = new List<ChoiceDto>();
				choiceList = GetChoiceByQuestionId(questionList[i].Id);

				for (int j = 0; j < choiceList.Count; j++)
				{

					var choiceItem = new Entity.Domain.Choice.Choice
					{
						UpdatedUser = Environment.UserName,
						UpdatedDate = DateTime.Now,
						IsActive = "0",
						ChoiceExplanation = choiceList[j].ChoiceExplanation,
						IsTrue = choiceList[j].IsTrue,
						QuestionId = choiceList[j].QuestionId,
						InsertedUser = choiceList[j].InsertedUser,
						InsertedDate = choiceList[j].InsertedDate,
						Id = choiceList[j].Id,
					};
					if (choiceItem != null)
					{
						context.Choices.Update(choiceItem);
					}
				}
			}
			try
			{
				await context.SaveChangesAsync();

			}
			catch (DbUpdateConcurrencyException)
			{
				// use an optimistic concurrency strategy from:
				// https://learn.microsoft.com/en-us/ef/core/saving/concurrency#resolving-concurrency-conflicts
			}

		}

		public List<QuestionDto> GetQuestionByExamId(int examId)
		{
			var result = context.Questions.AsNoTracking().Where(x => x.IsActive == "1" && x.ExamId == examId).ToList();
			var mappingResult = mapper.Map<List<QuestionDto>>(result);
			return mappingResult;
		}

		public List<ChoiceDto> GetChoiceByQuestionId(int questionId)
		{
			var result = context.Choices.AsNoTracking().Where(x => x.IsActive == "1" && x.QuestionId == questionId).ToList();
			var mappingResult = mapper.Map<List<ChoiceDto>>(result);
			return mappingResult;
		}
		public ExamDto GetExamById(int id)
        {

            var result = context.Exams.AsNoTracking().Where(x => x.IsActive == "1" && x.Id == id).FirstOrDefault();
            //var endTime = DateTime.ParseExact(result.ExamEndTime.ToString(), "M/d/yyyy HH:mm:ss",  CultureInfo.);
            var mappingResult = mapper.Map<ExamDto>(result);
            return mappingResult;
        }

        public List<ExamDto> GetExams()
        {
            // var result = context.Exams.AsNoTracking().Where(x => x.IsActive == "1").ToList();
            var result = context.Exams.AsNoTracking().Include(i => i.Course).Where(x => x.CourseId == x.Course.Id && x.IsActive == "1").ToList();
            var mappingResult = mapper.Map<List<ExamDto>>(result);
            return mappingResult;
            //return null;
        }

        public async Task Update(ExamDto examDto)
        {
            ArgumentNullException.ThrowIfNull(examDto);
            ArgumentNullException.ThrowIfNull(examDto.Id);
            ArgumentNullException.ThrowIfNull(examDto.ExamName);

            var exam = this.GetExamById((int)examDto.Id);

            if (exam == null)
            {
                throw new Exception("Böyle bir kayıt bulunamadı!");
            }

            exam.ExamName = examDto.ExamName;
            exam.ExamDescription = examDto.ExamDescription;
            exam.ExamStartTime = examDto.ExamStartTime;
            exam.ExamEndTime = examDto.ExamEndTime;
            exam.CourseId = examDto.CourseId;
            exam.UpdatedUser = Environment.UserName;
            exam.UpdatedDate = DateTime.Now;

            var mappingResult = mapper.Map<ExamDto, Entity.Domain.Exam.Exam>(exam);

            context.Set<Entity.Domain.Exam.Exam>().Update(mappingResult);
            await context.SaveChangesAsync();

        }



    }
}
