using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using UI.Constants;
using UI.Models.Choice;
using UI.Models.Question;
using UI.Models.QuestionManagement;
using UI.Models.QuestionType;

namespace UI.Controllers
{
    [Authorize(Roles = "Teacher")]
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
            List<QuestionTypeViewModel>? result = new List<QuestionTypeViewModel>();
            var response = await client.GetAsync(ApiEndpoints.GetQuestionTypeEndPoint).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<List<QuestionTypeViewModel>>(apiResponse);
            }
            ViewBag.ExamId = id;
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(QuestionViewModel viewModel)
        {
            List<QuestionViewModel>? questionDataResult = new List<QuestionViewModel>();
            List<QuestionViewModel>? result = new List<QuestionViewModel>();
            int questionId = 0;
            if (viewModel.QuestionTypeId == null || viewModel.QuestionTypeId == 0)
            {
                return null;
            }
            var json = JsonConvert.SerializeObject(viewModel, new JsonSerializerSettings { });
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(ApiEndpoints.CreateQuestionEndPoint, data).ConfigureAwait(false);

            return this.Redirect(Url.Action("Index", new { id = viewModel.ExamId }));
        }

        [HttpPost]
        public async Task<IActionResult> Update(QuestionViewModel viewModel)
        {
            if (viewModel.QuestionTypeId == null || viewModel.QuestionTypeId == 0)
            {
                return null;
            }
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

            var response2 = await client.GetAsync(ApiEndpoints.GetQuestionTypeEndPoint).ConfigureAwait(false);

            if (response2.IsSuccessStatusCode)
            {
                string apiResponse = await response2.Content.ReadAsStringAsync();
                list.QuestionTypeList = JsonConvert.DeserializeObject<List<QuestionTypeViewModel>>(apiResponse);
            }

            var response3 = await client.GetAsync(ApiEndpoints.GetChoiceByQuestionIdEndPoint + "/" + list.QuestionModel.Id).ConfigureAwait(false);

            if (response3.IsSuccessStatusCode)
            {
                string apiResponse = await response3.Content.ReadAsStringAsync();
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
