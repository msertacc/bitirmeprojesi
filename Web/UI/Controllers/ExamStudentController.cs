using AutoMapper;
using Entity.Domain.ApplicationUser;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;
using UI.Constants;
using UI.Models.Choice;
using UI.Models.Exam;
using UI.Models.ExamUser;
using UI.Models.Question;
using UI.Models.ViewModels;

namespace UI.Controllers
{
    public class ExamUserController : Controller
    {
        private readonly IMapper mapper;
        private readonly HttpClient client;
        private readonly UserManager<ApplicationUser> _userManager;
        public ExamUserController(IMapper mapper, HttpClient client, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            this.mapper = mapper;
            this.client = client;
        }
        public async Task<IActionResult> Index()
        {
            UserExamViewModel userExamViewModel = new UserExamViewModel();
            var userProfile = Environment.UserName;
            List<ExamUserViewModel>? examUserResult = new List<ExamUserViewModel>();
            var user = await _userManager.GetUserAsync(HttpContext.User);

            var response = await client.GetAsync(ApiEndpoints.GetExamUserByIdEndPoint  + "/" + user).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
				examUserResult = JsonConvert.DeserializeObject<List<ExamUserViewModel>>(apiResponse);
            }

			List<ExamViewModel>? resultExam = new List<ExamViewModel>();
			var responseExam = await client.GetAsync(ApiEndpoints.GetExamEndPoint).ConfigureAwait(false);

			if (responseExam.IsSuccessStatusCode)
			{
				string apiResponse = await responseExam.Content.ReadAsStringAsync();
				resultExam = JsonConvert.DeserializeObject<List<ExamViewModel>>(apiResponse);
			}
			userExamViewModel.ExamList = resultExam;
			userExamViewModel.ExamUserList = examUserResult;
			
            return View(userExamViewModel);
        }

		public async Task<IActionResult> StartExam(int examId)
		{
            ExamProcessViewModel examProcessViewModel = new ExamProcessViewModel();

            List<ExamViewModel>? resultExam = new List<ExamViewModel>();
            var responseExam = await client.GetAsync(ApiEndpoints.GetExamByIdEndPoint + "/" + examId).ConfigureAwait(false);

            if (responseExam.IsSuccessStatusCode)
            {
                string apiResponse = await responseExam.Content.ReadAsStringAsync();
                resultExam = JsonConvert.DeserializeObject<List<ExamViewModel>>(apiResponse);

                if (resultExam?[0].IsEnded != "0")
                {
                    return RedirectToAction("Index");
                }
            }

            List<QuestionViewModel>? resultQuestion = new List<QuestionViewModel>();
            var responseQuestion = await client.GetAsync(ApiEndpoints.GetQuestionsByExamIdEndPoint + "/" + examId).ConfigureAwait(false);

            if (responseQuestion.IsSuccessStatusCode)
            {
                string apiResponse = await responseQuestion.Content.ReadAsStringAsync();
                resultQuestion = JsonConvert.DeserializeObject<List<QuestionViewModel>>(apiResponse);
            }
            string idList = "";
            if(resultQuestion?.Count > 0)
            {
                resultQuestion.ForEach((i) =>
                {
                    idList += i.Id + ";";
                });
                idList = idList.Substring(0, idList.Length - 1);
                List<ChoiceViewModel>? resultChoice = new List<ChoiceViewModel>();
                var responseChoice = await client.GetAsync(ApiEndpoints.GetChoicesByQuestionIdListEndPoint + "/" + idList).ConfigureAwait(false);

                if (responseChoice.IsSuccessStatusCode)
                {
                    string apiResponse = await responseChoice.Content.ReadAsStringAsync();
                    resultChoice = JsonConvert.DeserializeObject<List<ChoiceViewModel>>(apiResponse);
                }
                examProcessViewModel.Exam = resultExam?[0];
                examProcessViewModel.Choice = resultChoice;
                examProcessViewModel.Question = resultQuestion;
            }
            return View("~/Views/ExamUser/Exam.cshtml", examProcessViewModel);
		}

		public ActionResult _Create()
        {
            var viewModel = new ExamUserViewModel();
            return PartialView(viewModel);
        }

    }
}
