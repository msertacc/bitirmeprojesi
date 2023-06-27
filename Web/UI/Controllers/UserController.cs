using AutoMapper;
using Entity.Domain.ApplicationUser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using System.Data;
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

        public async Task<IActionResult> Create(UserViewModel viewModel)
        {
            var errorMessage = "";
			var json = JsonConvert.SerializeObject(viewModel, new JsonSerializerSettings { });
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(ApiEndpoints.CreateUserEndPoint, data).ConfigureAwait(false);
            if (!response.IsSuccessStatusCode)
            {
                var byteArray = await response.Content.ReadAsByteArrayAsync();
                errorMessage = Encoding.UTF8.GetString(byteArray, 0, byteArray.Length);
            }
            return this.Redirect(Url.Action("Index"));
        }

        public async Task<ActionResult> _Update(Guid id)
        {
            var errorMessage = "";

			var response = await client.GetAsync(ApiEndpoints.GetUserByGuidEndPoint + "/" + id).ConfigureAwait(false);
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
            try
            {
				var response = await client.PostAsync(ApiEndpoints.UpdateUserEndPoint, data).ConfigureAwait(false);
			}
            catch (Exception ex)
            {

                throw;
            }
            
            return this.Redirect(Url.Action("Index"));
        }

        public async Task<ActionResult> _Delete(Guid id)
        {
            var errorMessage = "";

			var response = await client.GetAsync(ApiEndpoints.GetUserByGuidEndPoint + "/" + id).ConfigureAwait(false);
            var apiResponse = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                errorMessage = apiResponse;
            }

			var result = JsonConvert.DeserializeObject<UserViewModel>(apiResponse);
     
            return PartialView(result);
        }

        public async Task<ActionResult> Delete(Guid id)
        {
            var errorMessage = "";
            var json = JsonConvert.SerializeObject(id, new JsonSerializerSettings { });
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
