using Abstraction.Service.Choice;
using AutoMapper;
using Entity.Dto.Choice;
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

        [HttpGet("GetChoiceByQuestionId/{id:int}")]
        public IEnumerable<ChoiceDto> GetChoiceByQuestionId(int id)
        {
            var response = this.choiceService.GetChoiceByQuestionId(id);
            return response;
        }

        [HttpGet("GetChoicesByQuestionIdList/{idList}")]
        public IEnumerable<ChoiceDto> GetChoicesByQuestionIdList(string idList)
        {
            var response = this.choiceService.GetChoicesByQuestionIdList(idList);
            return response;
        }

    }
}
