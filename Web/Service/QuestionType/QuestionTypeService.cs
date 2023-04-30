using Abstraction.Service.Question;
using Abstraction.Service.QuestionType;
using AutoMapper;
using DataAccess.Data;
using Entity.Dto.Question;
using Entity.Dto.QuestionType;
using Microsoft.EntityFrameworkCore;

namespace Service.QuestionType
{
    public class QuestionTypeService : IQuestionTypeService
    {
        private ApplicationDbContext context;
        private IMapper mapper;

        public QuestionTypeService(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public Task Create(QuestionTypeDto questionTypeDto)
        {
            throw new NotImplementedException();
        }

        public Task Delete(QuestionTypeDto questionTypeDto)
        {
            throw new NotImplementedException();
        }

        public List<QuestionTypeDto> GetQuestionType()
        {
            var result = context.QuestionTypes.AsNoTracking().Where(x => x.IsActive == "1").ToList();
            var mappingResult = mapper.Map<List<QuestionTypeDto>>(result);
            return mappingResult;
        }

        public QuestionTypeDto GetQuestionTypeId(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(QuestionTypeDto questionTypeDto)
        {
            throw new NotImplementedException();
        }
    }
}
