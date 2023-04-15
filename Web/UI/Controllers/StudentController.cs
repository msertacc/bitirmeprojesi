using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using System.Text;
using UI.Constants;
using UI.Models.Course;
using UI.Models.Student;

namespace UI.Controllers
{
	public class StudentController:Controller
	{
		private readonly HttpClient client;
		private readonly IMapper mapper;
		public StudentController(HttpClient client, IMapper mapper)
		{
			this.client = client;
			this.mapper = mapper;
		}

		public async Task<ActionResult> Index()
		{
			List<StudentViewModel>? result = new List<StudentViewModel>();
			var response = await client.GetAsync(ApiEndpoints.GetStudentEndPoint).ConfigureAwait(false);

			if (response.IsSuccessStatusCode)
			{
				string apiResponse = await response.Content.ReadAsStringAsync();
				result = JsonConvert.DeserializeObject<List<StudentViewModel>>(apiResponse);
			}
			return View(result);
		}

		public ActionResult _Create()
		{
			var viewModel = new StudentViewModel();
			return PartialView(viewModel);
		}

		public async Task<ActionResult> Create(StudentViewModel viewModel)
		{
			var errorMessage = "";
			var json = JsonConvert.SerializeObject(viewModel, new JsonSerializerSettings { });
			var data = new StringContent(json, Encoding.UTF8, "application/json");
			var response = await client.PostAsync(ApiEndpoints.CreateStudentEndPoint, data).ConfigureAwait(false);
			if (!response.IsSuccessStatusCode)
			{
				errorMessage = response.Content.ReadAsStringAsync().Result;
			}
			return this.Redirect(Url.Action("Index"));
		}

		public async Task<ActionResult> _Update(int id)
		{
			var errorMessage = "";

			var query = new Dictionary<string, string>()
			{
				["studentId"] = id.ToString(),
			};

			var uri = QueryHelpers.AddQueryString(ApiEndpoints.GetStudentByIdEndPoint, query);
			var response = await client.GetAsync(uri).ConfigureAwait(false);
			var apiResponse = await response.Content.ReadAsStringAsync();
			if (!response.IsSuccessStatusCode)
			{
				errorMessage = apiResponse;
			}
			var result = JsonConvert.DeserializeObject<StudentViewModel>(apiResponse);
			return PartialView(result);
		}

		public async Task<ActionResult> Update(StudentViewModel viewModel)
		{
			var errorMessage = "";
			var json = JsonConvert.SerializeObject(viewModel, new JsonSerializerSettings { });
			var data = new StringContent(json, Encoding.UTF8, "application/json");
			var response = await client.PostAsync(ApiEndpoints.UpdateStudentEndPoint, data).ConfigureAwait(false);
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
				["studentId"] = id.ToString(),
			};

			var uri = QueryHelpers.AddQueryString(ApiEndpoints.GetStudentByIdEndPoint, query);
			var response = await client.GetAsync(uri).ConfigureAwait(false);
			var apiResponse = await response.Content.ReadAsStringAsync();
			if (!response.IsSuccessStatusCode)
			{
				errorMessage = apiResponse;
			}
			var result = JsonConvert.DeserializeObject<StudentViewModel>(apiResponse);
			return PartialView(result);
		}

		public async Task<ActionResult> Delete(StudentViewModel viewModel)
		{
			var errorMessage = "";
			var json = JsonConvert.SerializeObject(viewModel.Id, new JsonSerializerSettings { });
			var data = new StringContent(json, Encoding.UTF8, "application/json");
			var response = await client.PostAsync(ApiEndpoints.DeleteStudentEndPoint, data).ConfigureAwait(false);
			if (!response.IsSuccessStatusCode)
			{
				errorMessage = response.Content.ReadAsStringAsync().Result;
			}
			return this.Redirect(Url.Action("Index"));
		}
	}
}
