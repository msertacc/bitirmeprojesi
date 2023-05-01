using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UI.Constants;
using UI.Models.Course;
using UI.Models.ExamStudent;

namespace UI.Controllers
{
    public class ExamStudentController : Controller
    {
        private readonly IMapper mapper;
        private readonly HttpClient client;
        public ExamStudentController(IMapper mapper, HttpClient client)
        {
            this.mapper = mapper;
            this.client = client;
        }
        public async Task<IActionResult> Index()
        {
            List<ExamStudentViewModel>? result = new List<ExamStudentViewModel>();
            var response = await client.GetAsync(ApiEndpoints.GetExamStudentByIdEndPoint + "/1").ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<List<ExamStudentViewModel>>(apiResponse);
            }
            return View(result);
        }

		public IActionResult StartExam(int examId)
		{
            ViewBag.examId = examId;
			return View("~/Views/ExamStudent/Exam.cshtml");
		}

		public ActionResult _Create()
        {
            var viewModel = new ExamStudentViewModel();
            return PartialView(viewModel);
        }

    }
}
