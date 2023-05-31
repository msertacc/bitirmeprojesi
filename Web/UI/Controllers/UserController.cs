using AutoMapper;
using Entity.Domain.ApplicationUser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using System.Text;
using UI.Constants;
using UI.Models.User;

namespace UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController:Controller
	{
		private readonly HttpClient client;
		private readonly IMapper mapper;
		public UserController(HttpClient client, IMapper mapper)
		{
			this.client = client;
			this.mapper = mapper;
		}
		public async Task<ActionResult> Index()
		{
			List<ApplicationUser>? result = new List<ApplicationUser>();
			var response = await client.GetAsync(ApiEndpoints.GetUserEndPoint).ConfigureAwait(false);

			if (response.IsSuccessStatusCode)
			{
				string apiResponse = await response.Content.ReadAsStringAsync();
				result = JsonConvert.DeserializeObject<List<ApplicationUser>>(apiResponse);
			}
			return View(result);
		}

		public ActionResult _Create()
		{
			var viewModel = new UserViewModel();
			return PartialView(viewModel);
		}

		public async Task<ActionResult> Create(UserViewModel viewModel)
		{
			var errorMessage = "";
			var json = JsonConvert.SerializeObject(viewModel, new JsonSerializerSettings { });
			var data = new StringContent(json, Encoding.UTF8, "application/json");
			var response = await client.PostAsync(ApiEndpoints.CreateUserEndPoint, data).ConfigureAwait(false);
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
				["userId"] = id.ToString(),
			};

			var uri = QueryHelpers.AddQueryString(ApiEndpoints.GetUserByIdEndPoint, query);
			var response = await client.GetAsync(uri).ConfigureAwait(false);
			var apiResponse = await response.Content.ReadAsStringAsync();
			if (!response.IsSuccessStatusCode)
			{
				errorMessage = apiResponse;
			}
			var result = JsonConvert.DeserializeObject<UserViewModel>(apiResponse);
			return PartialView(result);
		}

		public async Task<ActionResult> Update(UserViewModel viewModel)
		{
			var errorMessage = "";
			var json = JsonConvert.SerializeObject(viewModel, new JsonSerializerSettings { });
			var data = new StringContent(json, Encoding.UTF8, "application/json");
			var response = await client.PostAsync(ApiEndpoints.UpdateUserEndPoint, data).ConfigureAwait(false);
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
				["userId"] = id.ToString(),
			};

			var uri = QueryHelpers.AddQueryString(ApiEndpoints.GetUserByIdEndPoint, query);
			var response = await client.GetAsync(uri).ConfigureAwait(false);
			var apiResponse = await response.Content.ReadAsStringAsync();
			if (!response.IsSuccessStatusCode)
			{
				errorMessage = apiResponse;
			}
			var result = JsonConvert.DeserializeObject<UserViewModel>(apiResponse);
			return PartialView(result);
		}

		public async Task<ActionResult> Delete(UserViewModel viewModel)
		{
			var errorMessage = "";
			var json = JsonConvert.SerializeObject(viewModel.Id, new JsonSerializerSettings { });
			var data = new StringContent(json, Encoding.UTF8, "application/json");
			var response = await client.PostAsync(ApiEndpoints.DeleteUserEndPoint, data).ConfigureAwait(false);
			if (!response.IsSuccessStatusCode)
			{
				errorMessage = response.Content.ReadAsStringAsync().Result;
			}
			return this.Redirect(Url.Action("Index"));
		}
	}
}
