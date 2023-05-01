namespace UI.Constants
{
	public static class ApiEndpoints
	{
		public static string? baseUrl = "https://localhost:7093";


		public static string? WeatherForecast = baseUrl + "/WeatherForecast";

		public static string? WeatherForecastGet = WeatherForecast + "";
        #region Course
        public static string? CourseEndPoint = baseUrl + "/Course";

		public static string? GetCourseEndPoint = CourseEndPoint + "/Get";

		public static string? GetCourseByIdEndPoint = CourseEndPoint + "/GetById";

		public static string? CreateCourseEndPoint = CourseEndPoint + "/Create";

		public static string? UpdateCourseEndPoint = CourseEndPoint + "/Update";

		public static string? DeleteCourseEndPoint = CourseEndPoint + "/Delete";
		#endregion
		#region Student
		public static string? StudentEndPoint = baseUrl + "/Student";

		public static string? GetStudentEndPoint = StudentEndPoint + "/Get";

		public static string? GetStudentByIdEndPoint = StudentEndPoint + "/GetById";

		public static string? CreateStudentEndPoint = StudentEndPoint + "/Create";

		public static string? UpdateStudentEndPoint = StudentEndPoint + "/Update";

		public static string? DeleteStudentEndPoint = StudentEndPoint + "/Delete";
		#endregion
		#region ExamStudent
		public static string? ExamStudentEndPoint = baseUrl + "/ExamStudent";

        public static string? GetExamStudentByIdEndPoint = ExamStudentEndPoint + "/GetExamByStudentId";
        #endregion
        //get
        //post
        //delete



    }
}
