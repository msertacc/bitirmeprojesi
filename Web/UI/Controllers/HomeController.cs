using UI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Newtonsoft.Json;
using UI.Constants;

namespace UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> IndexAsync()
        {          
			return View();
        }

  //      public IActionResult Privacy()
  //      {
		//	List<WeatherForecast>? result = new List<WeatherForecast>();
		//	string S = "";
		//	using (var httpClient = new HttpClient())
		//	{
		//		using (var response =  httpClient.GetAsync(ApiEndpoints.WeatherForecastGet))
		//		{

		//				string apiResponse =  response.Result.ToString();
		//			S = apiResponse;
		//		}
		//	}
		//	return View(S);
		//}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}