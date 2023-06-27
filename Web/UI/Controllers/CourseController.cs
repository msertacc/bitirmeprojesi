using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using System.Text;
using UI.Constants;
using UI.Models.Course;

namespace UI.Controllers
{
	[Authorize(Roles = "Admin")]
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

		public async Task<IActionResult> Create(CourseViewModel viewModel)
		{
			var errorMessage="";
			var json = JsonConvert.SerializeObject(viewModel, new JsonSerializerSettings { });
			var data = new StringContent(json, Encoding.UTF8, "application/json");
			var response = await client.PostAsync(ApiEndpoints.CreateCourseEndPoint, data).ConfigureAwait(false);
			if (!response.IsSuccessStatusCode)
			{
				var byteArray = await response.Content.ReadAsByteArrayAsync();
				errorMessage = Encoding.UTF8.GetString(byteArray, 0, byteArray.Length);
			}
			return this.Redirect(Url.Action("Index"));
		}

		public async Task<ActionResult> _Update(int id)
		{
			var errorMessage = "";

			var query = new Dictionary<string, string>()
			{
				["courseId"] = id.ToString(),
			};

			var uri = QueryHelpers.AddQueryString(ApiEndpoints.GetCourseByIdEndPoint, query);
			var response = await client.GetAsync(uri).ConfigureAwait(false);
			var apiResponse = await response.Content.ReadAsStringAsync();
			if (!response.IsSuccessStatusCode)
			{
				errorMessage = apiResponse;
			}
			var result = JsonConvert.DeserializeObject<CourseViewModel>(apiResponse);
			return PartialView(result);
		}

		public async Task<ActionResult> Update(CourseViewModel viewModel)
		{
			var errorMessage = "";
			var json = JsonConvert.SerializeObject(viewModel, new JsonSerializerSettings { });
			var data = new StringContent(json, Encoding.UTF8, "application/json");
			var response = await client.PostAsync(ApiEndpoints.UpdateCourseEndPoint, data).ConfigureAwait(false);
			if (!response.IsSuccessStatusCode)
			{
				errorMessage = response.Content.ReadAsStringAsync().Result;
			}
			return this.Redirect(Url.Action("Index"));
		}

		public async Task<ActionResult> _Delete(int id)
		{
			var errorMessage = "";

			var query = new Dictionary<string, string>()
			{
				["courseId"] = id.ToString(),
			};

			var uri = QueryHelpers.AddQueryString(ApiEndpoints.GetCourseByIdEndPoint, query);
			var response = await client.GetAsync(uri).ConfigureAwait(false);
			var apiResponse = await response.Content.ReadAsStringAsync();
			if (!response.IsSuccessStatusCode)
			{
				errorMessage = apiResponse;
			}
			var result = JsonConvert.DeserializeObject<CourseViewModel>(apiResponse);
			return PartialView(result);
		}

		public async Task<ActionResult> Delete(CourseViewModel viewModel)
		{
			var errorMessage = "";
			var json = JsonConvert.SerializeObject(viewModel.Id, new JsonSerializerSettings { });
			var data = new StringContent(json, Encoding.UTF8, "application/json");
			var response = await client.PostAsync(ApiEndpoints.DeleteCourseEndPoint, data).ConfigureAwait(false);
			if (!response.IsSuccessStatusCode)
			{
				errorMessage = response.Content.ReadAsStringAsync().Result;
			}
			return this.Redirect(Url.Action("Index"));
		}
	}
}
