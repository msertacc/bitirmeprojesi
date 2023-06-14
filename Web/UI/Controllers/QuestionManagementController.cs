using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using UI.Constants;
using UI.Models.Choice;
using UI.Models.Question;
using UI.Models.QuestionManagement;

namespace UI.Controllers
{
  //  [Authorize(Roles = "Teacher")]
    public class QuestionManagementController : Controller
    {
        private readonly IMapper mapper;
        private readonly HttpClient client;
        public QuestionManagementController(IMapper mapper, HttpClient client)
        {
            this.mapper = mapper;
            this.client = client;
        }
        public async Task<IActionResult> Index(int id = 0)
        {
            List<QuestionViewModel>? result = new List<QuestionViewModel>();
            var response = await client.GetAsync(ApiEndpoints.GetQuestionsByExamIdEndPoint + "/" + id).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<List<QuestionViewModel>>(apiResponse);
            }
            ViewBag.ExamId = id;
            return View(result);
        }

        public async Task<IActionResult> CreateQuestionAndAnswer(int id = 0)
        {
            ViewBag.ExamId = id;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(QuestionViewModel viewModel)
        {
            List<QuestionViewModel>? questionDataResult = new List<QuestionViewModel>();
            List<QuestionViewModel>? result = new List<QuestionViewModel>();
            int questionId = 0;
            var json = JsonConvert.SerializeObject(viewModel, new JsonSerializerSettings { });
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(ApiEndpoints.CreateQuestionEndPoint, data).ConfigureAwait(false);

            return this.Redirect(Url.Action("Index", new { id = viewModel.ExamId }));
        }

        [HttpPost]
        public async Task<IActionResult> Update(QuestionViewModel viewModel)
        {
            var json = JsonConvert.SerializeObject(viewModel, new JsonSerializerSettings { });
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(ApiEndpoints.UpdateQuestionEndPoint, data).ConfigureAwait(false);

            return this.Redirect(Url.Action("Index", new { id = viewModel.ExamId }));
        }

        public async Task<IActionResult> UpdateQuestionAndAnswer(int id = 0)
        {
            QuestionManagementViewModel list = new QuestionManagementViewModel();
            List<QuestionViewModel>? result = new List<QuestionViewModel>();

            var response = await client.GetAsync(ApiEndpoints.GetQuestionByIdEndPoint + "/" + id).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<List<QuestionViewModel>>(apiResponse);
                list.QuestionModel = result[0];
            }

            var choiceResponse = await client.GetAsync(ApiEndpoints.GetChoiceByQuestionIdEndPoint + "/" + list.QuestionModel.Id).ConfigureAwait(false);

            if (choiceResponse.IsSuccessStatusCode)
            {
                string apiResponse = await choiceResponse.Content.ReadAsStringAsync();
                list.ChoiceList = JsonConvert.DeserializeObject<List<ChoiceViewModel>>(apiResponse);
            }
            return View(list);
        }

        public async Task<ActionResult> _Delete(int id)
        {
            List<QuestionViewModel>? result = new List<QuestionViewModel>();
            var response = await client.GetAsync(ApiEndpoints.GetQuestionByIdEndPoint + "/" + id).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<List<QuestionViewModel>>(apiResponse);
            }
            return PartialView(result[0]);
        }

        public async Task<IActionResult> Delete(QuestionViewModel viewModel)
        {
            var json = JsonConvert.SerializeObject(viewModel, new JsonSerializerSettings { });
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(ApiEndpoints.DeleteQuestionEndPoint, data).ConfigureAwait(false);

            return this.Redirect(Url.Action("Index", new { id = viewModel.ExamId }));
        }
    }
}
