using AutoMapper;
using Entity.Domain.ApplicationUser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using UI.Constants;
using UI.Models.Course;
using UI.Models.Exam;

namespace UI.Controllers
{
    [Authorize(Roles = "Teacher")]
    public class ExamController : Controller
    {
        private readonly IMapper mapper;
        private readonly HttpClient client;
		private readonly UserManager<ApplicationUser> _userManager;

		public ExamController(IMapper mapper, HttpClient client, UserManager<ApplicationUser> userManager)
        {
			_userManager = userManager;
			this.mapper = mapper;
            this.client = client;
        }
        public async Task<IActionResult> Index()
        {
            List<ExamViewModel>? result = new List<ExamViewModel>();
			string user = _userManager.GetUserAsync(HttpContext.User).Result.Id;

			var response = await client.GetAsync(ApiEndpoints.GetExamEndPoint + "/" + user).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<List<ExamViewModel>>(apiResponse);
            }
            return View(result);
        }

        public async Task<ActionResult> _Create()
        {
            List<CourseViewModel>? result = new List<CourseViewModel>();

            string id = _userManager.GetUserAsync(HttpContext.User).Result.Id;

            var response = await client.GetAsync(ApiEndpoints.GetCourseByGuidEndPoint + "/" + id).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<List<CourseViewModel>>(apiResponse);
            }
            return PartialView(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ExamViewModel viewModel)
        {
            var json = JsonConvert.SerializeObject(viewModel, new JsonSerializerSettings { });
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(ApiEndpoints.CreateExamEndPoint, data).ConfigureAwait(false);

            return this.Redirect(Url.Action("Index"));
        }

        public async Task<ActionResult> _Delete(int id)
        {
            List<ExamViewModel>? result = new List<ExamViewModel>();
            var response = await client.GetAsync(ApiEndpoints.GetExamByIdEndPoint + "/" + id).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<List<ExamViewModel>>(apiResponse);
            }
            return PartialView(result[0]);
        }
        [HttpPost]
        public async Task<IActionResult> Delete([FromForm] ExamViewModel viewModel)
        {
            var json = JsonConvert.SerializeObject(viewModel, new JsonSerializerSettings { });
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(ApiEndpoints.DeleteExamEndPoint, data).ConfigureAwait(false);

            return this.Redirect(Url.Action("Index"));
        }

        public async Task<ActionResult> _Update(int id)
        {
            ExamAndCourseViewModel list = new ExamAndCourseViewModel();
            List<ExamViewModel>? result = new List<ExamViewModel>();
            List<CourseViewModel>? result2 = new List<CourseViewModel>();
            var response = await client.GetAsync(ApiEndpoints.GetExamByIdEndPoint + "/" + id).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<List<ExamViewModel>>(apiResponse);
                list.ExamViewModel = result[0];
            }
            string guid = _userManager.GetUserAsync(HttpContext.User).Result.Id;

            var response2 = await client.GetAsync(ApiEndpoints.GetCourseByGuidEndPoint + "/" + guid).ConfigureAwait(false);

            if (response2.IsSuccessStatusCode)
            {
                string apiResponse = await response2.Content.ReadAsStringAsync();
                list.CourseViewModel = JsonConvert.DeserializeObject<List<CourseViewModel>>(apiResponse);
            }

            return PartialView(list);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ExamViewModel viewModel)
        {
            var json = JsonConvert.SerializeObject(viewModel, new JsonSerializerSettings { });
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(ApiEndpoints.UpdateExamEndPoint, data).ConfigureAwait(false);

            return this.Redirect(Url.Action("Index"));
        }

    }
}
