using Abstraction.Service.Exam;
using Abstraction.Service.Question;
using API.Models.Exam;
using API.Models.Question;
using AutoMapper;
using Entity.Dto.Exam;
using Entity.Dto.Question;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Question
{
    [ApiController]
    [Route("[controller]")]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService questionService;
        private readonly IMapper mapper;
        public QuestionController(IQuestionService questionService, IMapper mapper)
        {
            this.questionService = questionService;
            this.mapper = mapper;
        }

        [HttpGet("Get")]
        public IEnumerable<QuestionDto> Get()
        {
            var response = this.questionService.GetQuestions();
            return response;
        }

        [HttpGet("GetQuestionsByExamId/{id:int}")]
        public IEnumerable<QuestionDto> GetQuestionsByExamId(int id)
        {
            var response = this.questionService.GetQuestionsByExamId(id);
            return response;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] QuestionCreateRequest model)
        {
            var mappingModel = this.mapper.Map<QuestionCreateRequest, QuestionDto>(model);
            await this.questionService.Create(mappingModel).ConfigureAwait(false);
            return this.Ok();
        }

        [HttpGet("GetQuestionById/{id:int}")]
        public IEnumerable<QuestionDto> GetQuestionById(int id)
        {
            var response = this.questionService.GetQuestionById(id);
            yield return response;
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> Delete([FromBody] QuestionCreateRequest model)
        {

            var mappingModel = this.mapper.Map<QuestionCreateRequest, QuestionDto>(model);
            await this.questionService.Delete(mappingModel).ConfigureAwait(false);
            return this.Ok();
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] QuestionCreateRequest model)
        {
            var mappingModel = this.mapper.Map<QuestionCreateRequest, QuestionDto>(model);
            await this.questionService.Update(mappingModel).ConfigureAwait(false);
            return this.Ok();
        }
    }
}
