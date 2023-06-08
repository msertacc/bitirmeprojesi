using Abstraction.Service.AnswerOfQuestionService;
using Abstraction.Service.Choice;
using API.Models.AnswerOfQuestion;
using API.Models.Question;
using AutoMapper;
using Entity.Dto.AnswerOfQuestion;
using Entity.Dto.Question;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.AnswerOfQuestion
{
    [ApiController]
    [Route("[controller]")]
    public class AnswerOfQuestionController : ControllerBase
    {
        private readonly IAnswerOfQuestionService answerOfQuestionService;
        private readonly IMapper mapper;
        public AnswerOfQuestionController(IAnswerOfQuestionService answerOfQuestionService, IMapper mapper)
        {
            this.answerOfQuestionService = answerOfQuestionService;
            this.mapper = mapper;
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] AnswerOfQuestionCreateRequest model)
        {
            var mappingModel = this.mapper.Map<AnswerOfQuestionCreateRequest, AnswerOfQuestionDto>(model);
            await this.answerOfQuestionService.Create(mappingModel).ConfigureAwait(false);
            return this.Ok();
        }
    }
}
