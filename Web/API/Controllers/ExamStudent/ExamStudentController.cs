using Abstraction.Service.Course;
using Abstraction.Service.ExamStudent;
using AutoMapper;
using Entity.Dto.Course;
using Entity.Dto.ExamStudent;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.ExamStudent
{
    [ApiController]
    [Route("[controller]")]
    public class ExamStudentController : ControllerBase
    {
        private readonly IExamStudentService examStudentService;
        private readonly IMapper mapper;

        public ExamStudentController(IExamStudentService examStudentService, IMapper mapper)
        {
            this.examStudentService = examStudentService;
            this.mapper = mapper;
        }

        [HttpGet("GetExamByStudentId/{userId}")]
        public List<ExamStudentDto> GetExamByStudentId(int userId)
        {
            var response = this.examStudentService.GetExamByStudent(userId);
            return response;
        }

    }
}
