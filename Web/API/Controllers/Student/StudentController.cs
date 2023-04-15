using Abstraction.Service.Student;
using API.Models.Student;
using AutoMapper;
using Entity.Dto.Course;
using Entity.Dto.Student;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Student
{
	[ApiController]
	[Route("[controller]")]
	public class StudentController:ControllerBase
	{
		private readonly IStudentService studentService;
		private readonly IMapper mapper;

		public StudentController(IStudentService studentService, IMapper mapper)
		{
			this.studentService = studentService;	
			this.mapper = mapper;
		}

		[HttpGet("Get")]
		public IEnumerable<StudentDto> Get()
		{
			var response = this.studentService.GetStudents();
			return response;
		}

		[HttpGet("GetById")]
		public StudentDto GetById(int studentId)
		{
			var response = this.studentService.GetStudentById(studentId);
			return response;
		}

		[HttpPost("Create")]
		public async Task<IActionResult> Create([FromBody] StudentCreateRequest model)
		{
			try
			{
				var mappingModel = this.mapper.Map<StudentCreateRequest, StudentDto>(model);

				await this.studentService.Create(mappingModel).ConfigureAwait(false);

				return this.Ok();
			}
			catch (Exception ex)
			{

				return this.BadRequest(ex.Message);
			}

		}

		[HttpPost("Update")]
		public async Task<IActionResult> Update([FromBody] StudentUpdateRequest model)
		{
			try
			{
				var mappingModel = this.mapper.Map<StudentUpdateRequest, StudentDto>(model);

				await this.studentService.Update(mappingModel).ConfigureAwait(false);

				return this.Ok();
			}
			catch (Exception ex)
			{

				return this.BadRequest(ex.Message);
			}

		}

		[HttpPost("Delete")]
		public async Task<IActionResult> Delete([FromBody] int studentId)
		{
			try
			{
				await this.studentService.Delete(studentId).ConfigureAwait(false);

				return this.Ok();
			}
			catch (Exception ex)
			{

				return this.BadRequest(ex.Message);
			}

		}
	}
}
