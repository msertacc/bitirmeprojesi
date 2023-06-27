using AutoMapper;
using Entity.Domain.ApplicationUser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using System.Text;
using UI.Constants;
using UI.Models.Course;
using UI.Models.StudentCourse;

namespace UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class StudentCourseController : Controller
    {
        private readonly IMapper mapper;
        private readonly HttpClient client;
		string userFullName = "";

		public StudentCourseController(IMapper mapper, HttpClient client)
        {
            this.mapper = mapper;
            this.client = client;
        }
        public async Task<IActionResult> Index(Guid id)
        {
			
			ViewBag.UserId = id;
            StudentCourseViewModel? result = new StudentCourseViewModel();


			var userInfo = await client.GetAsync(ApiEndpoints.GetUserByGuidEndPoint+"/"+id).ConfigureAwait(false);

			if (userInfo.IsSuccessStatusCode)
			{
				string apiResponse = await userInfo.Content.ReadAsStringAsync();
				result.UserInfo = JsonConvert.DeserializeObject<ApplicationUser>(apiResponse);
                ViewBag.UserFullName = result.UserInfo.FirstName + " " + result.UserInfo.LastName;
			}

			var courseList = await client.GetAsync(ApiEndpoints.GetCourseEndPoint).ConfigureAwait(false);

            if (courseList.IsSuccessStatusCode)
            {
                string apiResponse = await courseList.Content.ReadAsStringAsync();
                result.CourseList = JsonConvert.DeserializeObject<List<CourseViewModel>>(apiResponse);
            }
			var response = await client.GetAsync(ApiEndpoints.GetStudentCourseByUserIdEndPoint + "/" + id).ConfigureAwait(false);

			if (response.IsSuccessStatusCode)
			{
				string apiResponse = await response.Content.ReadAsStringAsync();
				result.UsersCourseList = JsonConvert.DeserializeObject<List<UsersCourseModel>>(apiResponse);
			}
            ViewBag.UserId = id;
			return View(result);
        }

		public async Task<ActionResult> _Delete(int id)
		{
			var errorMessage = "";

			var query = new Dictionary<string, string>()
			{
				["id"] = id.ToString(),
			};

			var uri = QueryHelpers.AddQueryString(ApiEndpoints.GetStudentCourseByIdEndPoint, query);
			var response = await client.GetAsync(uri).ConfigureAwait(false);
			var apiResponse = await response.Content.ReadAsStringAsync();
			if (!response.IsSuccessStatusCode)
			{
				errorMessage = apiResponse;
			}
			var result = JsonConvert.DeserializeObject<UsersCourseModel>(apiResponse);
			return PartialView(result);
		}

		public async Task<JsonResult> Delete(UsersCourseModel viewModel)
		{
			var errorMessage = "";
			var json = JsonConvert.SerializeObject(viewModel.Id, new JsonSerializerSettings { });
			var data = new StringContent(json, Encoding.UTF8, "application/json");
			var response = await client.PostAsync(ApiEndpoints.DeleteStudentCourseEndPoint, data).ConfigureAwait(false);
			if (!response.IsSuccessStatusCode)
			{
				errorMessage = response.Content.ReadAsStringAsync().Result;
			}
            return Json("");
        }

		public async Task<JsonResult> Create(UsersCourseModel viewModel)
		{
			var errorMessage = "";
			var json = JsonConvert.SerializeObject(viewModel, new JsonSerializerSettings { });
			var data = new StringContent(json, Encoding.UTF8, "application/json");
			var response = await client.PostAsync(ApiEndpoints.CreateStudentCourseEndPoint, data).ConfigureAwait(false);
			if (!response.IsSuccessStatusCode)
			{
				var byteArray = await response.Content.ReadAsByteArrayAsync();
				errorMessage = Encoding.UTF8.GetString(byteArray, 0, byteArray.Length);
			}
			return Json("");
		}

		public async Task<PartialViewResult> _DataGrid(Guid id)
		{
			StudentCourseViewModel? result = new StudentCourseViewModel();
			var response = await client.GetAsync(ApiEndpoints.GetStudentCourseByUserIdEndPoint + "/" + id).ConfigureAwait(false);

			if (response.IsSuccessStatusCode)
			{
				string apiResponse = await response.Content.ReadAsStringAsync();
				result.UsersCourseList = JsonConvert.DeserializeObject<List<UsersCourseModel>>(apiResponse);
			}
			return PartialView(result.UsersCourseList);
		}
	}
}
