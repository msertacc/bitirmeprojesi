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

		[HttpGet("GetById")]
		public CourseDto GetById(int courseId)
		{
			var response = this.courseService.GetCourseById(courseId);
			return response;
		}

		[HttpPost("Create")]
		public async Task<IActionResult> Create([FromBody] CourseCreateRequest model)
		{

			var mappingModel = this.mapper.Map<CourseCreateRequest, CourseDto>(model);

			await this.courseService.Create(mappingModel).ConfigureAwait(false);

			return this.Ok();


		}

		[HttpPost("Update")]
		public async Task<IActionResult> Update([FromBody] CourseUpdateRequest model)
		{
			try
			{
				var mappingModel = this.mapper.Map<CourseUpdateRequest, CourseDto>(model);

				await this.courseService.Update(mappingModel).ConfigureAwait(false);

				return this.Ok();
			}
			catch (Exception ex)
			{

				return this.BadRequest(ex.Message);
			}

		}

		[HttpPost("Delete")]
		public async Task<IActionResult> Delete([FromBody] int courseId)
		{
			try
			{
				await this.courseService.Delete(courseId).ConfigureAwait(false);

				return this.Ok();
			}
			catch (Exception ex)
			{

				return this.BadRequest(ex.Message);
			}

		}
	}
}
