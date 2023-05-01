using Abstraction.Service.Choice;
using AutoMapper;
using DataAccess.Data;
using Entity.Dto.Choice;
using Entity.Dto.Exam;
using Entity.Dto.Question;
using Microsoft.EntityFrameworkCore;

namespace Service.Choice
{
    public class ChoiceService : IChoiceService
    {
        private ApplicationDbContext context;
        private IMapper mapper;

        public ChoiceService(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task Create(ChoiceDto choiceDto)
        {
            throw new NotImplementedException();
        }


        public Task Delete(ChoiceDto choiceDto)
        {
            throw new NotImplementedException();
        }

        public ChoiceDto GetChoiceById(int id)
        {
            throw new NotImplementedException();
        }

        public List<ChoiceDto> GetChoices()
        {
            throw new NotImplementedException();
        }

        public Task Update(ChoiceDto choiceDto)
        {
            throw new NotImplementedException();
        }

        public List<ChoiceDto> GetChoiceByQuestionId(int questionId)
        {
            var result = context.Choices.AsNoTracking().Where(x => x.IsActive == "1" && x.QuestionId == questionId).ToList();
            var mappingResult = mapper.Map<List<ChoiceDto>>(result);
            return mappingResult;
        }
    }
}
