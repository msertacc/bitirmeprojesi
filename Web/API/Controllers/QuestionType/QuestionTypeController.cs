using Abstraction.Service.Question;
using Abstraction.Service.QuestionType;
using AutoMapper;
using Entity.Dto.Question;
using Entity.Dto.QuestionType;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.QuestionType
{
    [ApiController]
    [Route("[controller]")]
    public class QuestionTypeController : ControllerBase
    {
        private readonly IQuestionTypeService questionTypeService;
        private readonly IMapper mapper;
        public QuestionTypeController(IQuestionTypeService questionTypeService, IMapper mapper)
        {
            this.questionTypeService = questionTypeService;
            this.mapper = mapper;
        }


        [HttpGet("Get")]
        public IEnumerable<QuestionTypeDto> Get()
        {
            var response = this.questionTypeService.GetQuestionType();
            return response;
        }
    }
}
