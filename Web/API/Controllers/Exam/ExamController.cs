using Abstraction.Service.Exam;
using API.Models.Course;
using API.Models.Exam;
using AutoMapper;
using Entity.Dto.Course;
using Entity.Dto.Exam;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Exam
{
    [ApiController]
    [Route("[controller]")]
    public class ExamController : ControllerBase
    {
        private readonly IExamService examService;
        private readonly IMapper mapper;

        public ExamController(IExamService examService, IMapper mapper)
        {
            this.examService = examService;
            this.mapper = mapper;
        }

        [HttpGet("Get")]
        public IEnumerable<ExamDto> Get()
        {
            var response = this.examService.GetExams();
            return response;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] ExamCreateRequest model)
        {
            var mappingModel = this.mapper.Map<ExamCreateRequest, ExamDto>(model);
            await this.examService.Create(mappingModel).ConfigureAwait(false);
            return this.Ok();
        }

        [HttpGet("GetExamById/{id:int}")]
        public IEnumerable<ExamDto> GetExamById(int id)
        {
            var response = this.examService.GetExamById(id);
            yield return response;
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> Delete([FromBody] ExamCreateRequest model)
        {

            var mappingModel = this.mapper.Map<ExamCreateRequest, ExamDto>(model);
            await this.examService.Delete(mappingModel).ConfigureAwait(false);
            return this.Ok();
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] ExamCreateRequest model)
        {
            var mappingModel = this.mapper.Map<ExamCreateRequest, ExamDto>(model);
            await this.examService.Update(mappingModel).ConfigureAwait(false);
            return this.Ok();
        }

    }
}
