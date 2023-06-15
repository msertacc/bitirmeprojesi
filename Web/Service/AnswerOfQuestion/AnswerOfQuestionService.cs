using Abstraction.Service.AnswerOfQuestionService;
using AutoMapper;
using DataAccess.Data;
using Entity.Dto.AnswerOfQuestion;
using Entity.Dto.Question;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.AnswerOfQuestion
{
    public class AnswerOfQuestionService:IAnswerOfQuestionService
    {
        private ApplicationDbContext context;
        private IMapper mapper;
        public AnswerOfQuestionService(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task Create(AnswerOfQuestionDto answerOfQuestionDto)
        {
            ArgumentNullException.ThrowIfNull(answerOfQuestionDto);

            answerOfQuestionDto.InsertedUser = Environment.UserName;
            answerOfQuestionDto.InsertedDate = DateTime.Now;
            answerOfQuestionDto.IsActive = "1";

            var mappingResult = mapper.Map<AnswerOfQuestionDto, Entity.Domain.AnswerOfQuestion.AnswerOfQuestion>(answerOfQuestionDto);

            for (int i = 0; i < answerOfQuestionDto.AnswerList.Count; i++)
            {
                var choiceItem = new Entity.Domain.AnswerOfQuestion.AnswerOfQuestion
                {
                    UserId = answerOfQuestionDto.UserId,
                    ExamId = answerOfQuestionDto.ExamId,
                    QuestionId = answerOfQuestionDto.AnswerList[i].QuestionId,   
                    ChoiceId = answerOfQuestionDto.AnswerList[i].ChoiceId, 
                    InsertedUser = Environment.UserName,
                    InsertedDate = DateTime.Now,
                    IsActive = "1",
                };
                await context.AnswerOfQuestions.AddAsync(choiceItem);
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
