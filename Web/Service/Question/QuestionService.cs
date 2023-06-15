using Abstraction.Service.Question;
using AutoMapper;
using DataAccess.Data;
using Entity.Dto.Choice;
using Entity.Dto.Question;
using Microsoft.EntityFrameworkCore;

namespace Service.Question
{
	public class QuestionService : IQuestionService
    {
        private ApplicationDbContext context;
        private IMapper mapper;

        public QuestionService(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task Create(QuestionDto newQuestionDto)
        {
            ArgumentNullException.ThrowIfNull(newQuestionDto);
            ArgumentNullException.ThrowIfNull(newQuestionDto.QuestionText);

            newQuestionDto.InsertedUser = Environment.UserName;
            newQuestionDto.InsertedDate = DateTime.Now;
            newQuestionDto.IsActive = "1";

            var mappingResult = mapper.Map<QuestionDto, Entity.Domain.Question.Question>(newQuestionDto);

            await context.Set<Entity.Domain.Question.Question>().AddAsync(mappingResult);
            await context.SaveChangesAsync();

            QuestionDto questionInfo = new QuestionDto();
            questionInfo = GetQuestionsByParameters(newQuestionDto.QuestionText, newQuestionDto.Score);

            ArgumentNullException.ThrowIfNull(questionInfo.Id);

            for (int i = 0; i < newQuestionDto.AnswerArray.Length; i++)
            {
                bool isTrue = false;
                if (newQuestionDto.TrueAnswer == i)
                {
                    isTrue = true;
                }
                var choiceItem = new Entity.Domain.Choice.Choice
                {
                    ChoiceExplanation = newQuestionDto.AnswerArray[i],
                    IsTrue = isTrue,
                    QuestionId = questionInfo.Id,                                              
                    InsertedUser = Environment.UserName,
                    InsertedDate = DateTime.Now,
                    IsActive = "1",
                };

                await context.Choices.AddAsync(choiceItem);
            }

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
            }
        }

        public async Task Delete(QuestionDto questionDto)
        {
            ArgumentNullException.ThrowIfNull(questionDto.Id);

            var exam = this.GetQuestionById(questionDto.Id);
            if (exam == null)
            {
                throw new Exception("Böyle bir kayıt bulunamadı!");
            }

            exam.IsActive = "0";
            exam.UpdatedUser = Environment.UserName;
            exam.UpdatedDate = DateTime.Now;

            var mappingResult = mapper.Map<QuestionDto, Entity.Domain.Question.Question>(exam);
            context.Set<Entity.Domain.Question.Question>().Update(mappingResult);
            await context.SaveChangesAsync();

            List<ChoiceDto> choiceList = new List<ChoiceDto>();
            choiceList = GetChoiceByQuestionId(questionDto.Id);

            for (int i = 0; i < choiceList.Count; i++)
            {

                var choiceItem = new Entity.Domain.Choice.Choice
                {
                    UpdatedUser = Environment.UserName,
                    UpdatedDate = DateTime.Now,
                    IsActive = "0",
                    ChoiceExplanation = choiceList[i].ChoiceExplanation,
                    IsTrue = choiceList[i].IsTrue,
                    QuestionId = choiceList[i].QuestionId,
                    InsertedUser = choiceList[i].InsertedUser,
                    InsertedDate = choiceList[i].InsertedDate,
                    Id = choiceList[i].Id,
                };
                if (choiceItem != null)
                {
                    context.Choices.Update(choiceItem);
                }
            }

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                
            }
        }

        public List<ChoiceDto> GetChoiceByQuestionId(int questionId)
        {
            var result = context.Choices.AsNoTracking().Where(x => x.IsActive == "1" && x.QuestionId == questionId).ToList();
            var mappingResult = mapper.Map<List<ChoiceDto>>(result);
            return mappingResult;
        }

        public QuestionDto GetQuestionById(int id)
        {
            var result = context.Questions.AsNoTracking().Where(x => x.IsActive == "1" && x.Id == id).FirstOrDefault();
            var mappingResult = mapper.Map<QuestionDto>(result);
            return mappingResult;
        }

        public List<QuestionDto> GetQuestions()
        {
            var result = context.Questions.AsNoTracking().Where(x => x.IsActive == "1").ToList();   
            var mappingResult = mapper.Map<List<QuestionDto>>(result);
            return mappingResult;
        }

        public List<QuestionDto> GetQuestionsByExamId(int id)
        {
            var result = context.Questions.AsNoTracking().Where(x => x.IsActive == "1" && x.ExamId == id).ToList();
            var mappingResult = mapper.Map<List<QuestionDto>>(result);
            return mappingResult;
        }

        public QuestionDto GetQuestionsByParameters(string questionText, int score)
        {
            var result = context.Questions.AsNoTracking().Where(x => x.QuestionText == questionText && x.Score == score).FirstOrDefault();
            var mappingResult = mapper.Map<QuestionDto>(result);
            return mappingResult;
        }

        public async Task Update(QuestionDto questionDto)
        {
            ArgumentNullException.ThrowIfNull(questionDto);
            ArgumentNullException.ThrowIfNull(questionDto.Id);
            ArgumentNullException.ThrowIfNull(questionDto.QuestionText);

            var question = this.GetQuestionById((int)questionDto.Id);

            if (question == null)
            {
                throw new Exception("Böyle bir kayıt bulunamadı!");
            }

            question.QuestionText = questionDto.QuestionText;
            question.Score = questionDto.Score;
            question.UpdatedUser = Environment.UserName;
            question.UpdatedDate = DateTime.Now;

            var mappingResult = mapper.Map<QuestionDto, Entity.Domain.Question.Question>(question);

            context.Set<Entity.Domain.Question.Question>().Update(mappingResult);
            await context.SaveChangesAsync();

            List<ChoiceDto> choiceList = new List<ChoiceDto>();
            choiceList = GetChoiceByQuestionId(questionDto.Id);

            for (int i = 0; i < choiceList.Count; i++)
            {

                var choiceItem = new Entity.Domain.Choice.Choice
                {
                    UpdatedUser = Environment.UserName,
                    UpdatedDate = DateTime.Now,
                    IsActive = "0",
                    ChoiceExplanation = choiceList[i].ChoiceExplanation,
                    IsTrue = choiceList[i].IsTrue,
                    QuestionId = choiceList[i].QuestionId,
                    InsertedUser = choiceList[i].InsertedUser,
                    InsertedDate = choiceList[i].InsertedDate,
                    Id = choiceList[i].Id,
                };
                if (choiceItem != null)
                {
                    context.Choices.Update(choiceItem);
                }
            }

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                
            }

            for (int i = 0; i < questionDto.AnswerArray.Length; i++)
            {
                bool isTrue = false;
                if (questionDto.TrueAnswer == i)
                {
                    isTrue = true;
                }
                var choiceItem = new Entity.Domain.Choice.Choice
                {
                    ChoiceExplanation = questionDto.AnswerArray[i],
                    IsTrue = isTrue,
                    QuestionId = questionDto.Id,
                    InsertedUser = Environment.UserName,
                    InsertedDate = DateTime.Now,
                    IsActive = "1",
                };

                await context.Choices.AddAsync(choiceItem);
            }

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                
            }

        }
    }
}
