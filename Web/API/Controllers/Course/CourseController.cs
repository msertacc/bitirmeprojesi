using Abstraction.Service.Course;
using API.Models.Course;
using AutoMapper;
using Entity.Dto.Course;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Course
{
	[ApiController]
	[Route("[controller]")]
	public class CourseController : ControllerBase
	{
		private readonly ICourseService courseService;
		private readonly IMapper mapper;

		public CourseController(ICourseService courseService, IMapper mapper)
		{
			this.courseService = courseService;
			this.mapper = mapper;
		}

		[HttpGet("Get")]
		public IEnumerable<CourseDto> Get()
		{
			var response = this.courseService.GetCourses();
			return response;
		}

		[HttpPost("Create")]
		public async Task<IActionResult> Create([FromBody] CourseCreateRequest model)
		{
			var mappingModel = this.mapper.Map<CourseCreateRequest, CourseDto>(model);

			await this.courseService.Create(mappingModel).ConfigureAwait(false);

			return this.Ok();

		}
	}
}
