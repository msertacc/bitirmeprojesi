using Abstraction.Service.Question;
using Abstraction.Service.StudentCourse;
using API.Models.Choice;
using API.Models.Course;
using API.Models.Exam;
using API.Models.UserCourse;
using AutoMapper;
using Entity.Domain.Course;
using Entity.Dto.Choice;
using Entity.Dto.Course;
using Entity.Dto.Exam;
using Entity.Dto.Question;
using Entity.Dto.StudentCourse;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.StudentCourse
{
    [ApiController]
    [Route("[controller]")]
    public class StudentCourseController : ControllerBase
    {
        private readonly IStudentCourseService studentCourseService;
        private readonly IMapper mapper;
        public StudentCourseController(IStudentCourseService studentCourseService, IMapper mapper)
        {
            this.studentCourseService = studentCourseService;
            this.mapper = mapper;
        }

        [HttpGet("GetStudentCourseByUserId/{id:Guid}")]
        public IEnumerable<StudentCourseDto> GetStudentCourseByUserId(Guid id)
        {
            var response = this.studentCourseService.GetStudentCourse(id);
            return response;
        }

		[HttpGet("GetById")]
		public StudentCourseDto GetById(int id)
		{
			var response = this.studentCourseService.GetStudentCourseById(id);
			return response;
		}

		[HttpPost("Create")]
		public async Task<IActionResult> Create([FromBody] UserCourseCreateRequest model)
		{

			var mappingModel = this.mapper.Map<UserCourseCreateRequest, StudentCourseDto>(model);

			await this.studentCourseService.Create(mappingModel).ConfigureAwait(false);

			return this.Ok();

		}

		[HttpPost("Delete")]
		public async Task<IActionResult> Delete([FromBody] int  id)
		{
			try
			{
				await this.studentCourseService.Delete(id).ConfigureAwait(false);

				return this.Ok();
			}
			catch (Exception ex)
			{

				return this.BadRequest(ex.Message);
			}

		}
	}
}
