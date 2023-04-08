using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using UI.Constants;
using UI.Models.Course;

namespace UI.Controllers
{
	//[Authorize]
	public class CourseController : Controller
	{
		private readonly IMapper mapper;
		private readonly HttpClient client;
		public CourseController(IMapper mapper, HttpClient client)
		{
			this.mapper = mapper;
			this.client = client;
		}
		public async Task<IActionResult> Index()
		{
			List<CourseViewModel>? result = new List<CourseViewModel>();
			var response = await client.GetAsync(ApiEndpoints.GetCourseEndPoint).ConfigureAwait(false);

			if (response.IsSuccessStatusCode)
			{
				string apiResponse = await response.Content.ReadAsStringAsync();
				result = JsonConvert.DeserializeObject<List<CourseViewModel>>(apiResponse);
			}
			return View(result);
		}

		public ActionResult _Create()
		{
			var viewModel = new CourseViewModel();
			return PartialView(viewModel);
		}

		[HttpPost]
		public async Task<IActionResult> Create(CourseViewModel viewModel)
		{
			var json = JsonConvert.SerializeObject(viewModel, new JsonSerializerSettings { });
			var data = new StringContent(json, Encoding.UTF8, "application/json");
			var response = await client.PostAsync(ApiEndpoints.CreateCourseEndPoint, data).ConfigureAwait(false);

			return this.Redirect(Url.Action("Index"));
		}

		//public ActionResult _Update(int id)
		//{
		//	var result = this.courseService.GetCourseById(id);
		//	var mappingResult = this.mapper.Map<CourseDto, CourseViewModel>(result);
		//	return PartialView(mappingResult);
		//}

		//public ActionResult Update(CourseViewModel viewModel)
		//{
		//	var mappingResult = this.mapper.Map<CourseViewModel, CourseDto>(viewModel);
		//	this.courseService.Update(mappingResult);
		//	return this.Redirect(Url.Action("Index"));
		//}

		//public ActionResult _Delete(int id)
		//{
		//	var result = this.courseService.GetCourseById(id);
		//	var mappingResult = this.mapper.Map<CourseDto, CourseViewModel>(result);
		//	return PartialView(mappingResult);
		//}

		//public ActionResult Delete(CourseViewModel viewModel)
		//{
		//	this.courseService.Delete(viewModel.Id);
		//	return this.Redirect(Url.Action("Index"));
		//}
	}
}
