using Abstraction.Service.Choice;
using Abstraction.Service.Question;
using API.Models.Choice;
using API.Models.Exam;
using API.Models.Question;
using AutoMapper;
using Entity.Dto.Choice;
using Entity.Dto.Exam;
using Entity.Dto.Question;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Choice
{
    [ApiController]
    [Route("[controller]")]
    public class ChoiceController : ControllerBase
    {
        private readonly IChoiceService choiceService;
        private readonly IMapper mapper;
        public ChoiceController(IChoiceService choiceService, IMapper mapper)
        {
            this.choiceService = choiceService;
            this.mapper = mapper;
        }

        //[HttpPost("Create")]
        //public async Task<IActionResult> Create([FromBody] ChoiceCreateRequest model)
        //{
        //    model.QuestionId = model.Id;
        //    model.Id = 0;
        //    var mappingModel = this.mapper.Map<ChoiceCreateRequest, ChoiceDto>(model);
        //    await this.choiceService.Create(mappingModel).ConfigureAwait(false);
        //    return this.Ok();
        //}
        [HttpGet("GetChoiceByQuestionId/{id:int}")]
        public IEnumerable<ChoiceDto> GetChoiceByQuestionId(int id)
        {
            var response = this.choiceService.GetChoiceByQuestionId(id);
            return response;
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> Delete([FromBody] ChoiceCreateRequest model)
        {

            var mappingModel = this.mapper.Map<ChoiceCreateRequest, ChoiceDto>(model);
            await this.choiceService.Delete(mappingModel).ConfigureAwait(false);
            return this.Ok();
        }
    }
}
