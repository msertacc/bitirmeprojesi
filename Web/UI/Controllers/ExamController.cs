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
   // [Authorize(Roles = "Teacher")]
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
			//string user = Environment.UserName; //_userManager.GetUserAsync(HttpContext.User).Result.Id;
			//string guidString = "bc5cbb76-0b16-472d-8ab0-3453ece564dc";
			//Guid manualGuid = new Guid(guidString);
			string user = _userManager.GetUserAsync(HttpContext.User).Result.Id;

			//var response = await client.GetAsync(ApiEndpoints.GetExamUserByIdEndPoint + "/" + user).ConfigureAwait(false);
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
            var response = await client.GetAsync(ApiEndpoints.GetCourseEndPoint).ConfigureAwait(false);

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

            var response2 = await client.GetAsync(ApiEndpoints.GetCourseEndPoint).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
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
