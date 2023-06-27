using Abstraction.Service.ExamUser;
using API.Models.ExamUser;
using API.Models.Question;
using AutoMapper;
using Entity.Dto.ExamUser;
using Entity.Dto.Question;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.ExamUser
{
    [ApiController]
    [Route("[controller]")]
    public class ExamUserController : ControllerBase
    {
        private readonly IExamUserService examUserService;
        private readonly IMapper mapper;

        public ExamUserController(IExamUserService examUserService, IMapper mapper)
        {
            this.examUserService = examUserService;
            this.mapper = mapper;
        }

        [HttpGet("GetExamByUserId/{id}")]
        public List<ExamUserDto> GetExamByUserId(string id)
        {
            var response = this.examUserService.GetExamByUser(id);
            return response;
        }

        [HttpGet("GetResultsForExamsByUserId/{id}")]
        public IEnumerable<ResultExamDto> GetResultsForExamsByUserId(Guid id)
        {
            var response = this.examUserService.GetResultsForExams(id);
            return response;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] ExamUserDto dto)
        {
            await this.examUserService.Create(dto).ConfigureAwait(false);
            return this.Ok();
        }


        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] ExamUserUpdateRequest req)
        {
            await this.examUserService.Update(req.ExamId, req.UserId).ConfigureAwait(false);
            return this.Ok();
        }
    }
}
