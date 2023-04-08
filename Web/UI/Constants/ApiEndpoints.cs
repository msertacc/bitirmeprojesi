namespace UI.Constants
{
	public static class ApiEndpoints
	{
		public static string? baseUrl = "https://localhost:7093";


		public static string? WeatherForecast = baseUrl + "/WeatherForecast";

		public static string? WeatherForecastGet = WeatherForecast + "";

		public static string? CourseEndPoint = baseUrl + "/Course";

		public static string? GetCourseEndPoint = CourseEndPoint + "/Get";

		public static string? CreateCourseEndPoint = CourseEndPoint + "/Create";
		//get
		//post
		//delete

	}
}
