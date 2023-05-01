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

        public static string? ExamEndPoint = baseUrl + "/Exam";

        public static string? GetExamEndPoint = ExamEndPoint + "/Get";

        public static string? GetExamByIdEndPoint = ExamEndPoint + "/GetExamById";

        public static string? CreateExamEndPoint = ExamEndPoint + "/Create";

        public static string? DeleteExamEndPoint = ExamEndPoint + "/Delete";

        public static string? UpdateExamEndPoint = ExamEndPoint + "/Update";


        public static string? QuestionEndPoint = baseUrl + "/Question";

        public static string? GetQuestionEndPoint = QuestionEndPoint + "/Get"; //GetQuestionsByExamId

        public static string? GetQuestionsByExamIdEndPoint = QuestionEndPoint + "/GetQuestionsByExamId";

        public static string? GetQuestionsByParametersEndPoint = QuestionEndPoint + "/GetQuestionsByParameters";

        public static string? GetQuestionByIdEndPoint = QuestionEndPoint + "/GetQuestionById";

        public static string? CreateQuestionEndPoint = QuestionEndPoint + "/Create";

        public static string? DeleteQuestionEndPoint = QuestionEndPoint + "/Delete";

        public static string? UpdateQuestionEndPoint = QuestionEndPoint + "/Update";



        public static string? QuestionTypeEndPoint = baseUrl + "/QuestionType";

        public static string? GetQuestionTypeEndPoint = QuestionTypeEndPoint + "/Get";

        public static string? GetQuestionTypeByIdEndPoint = QuestionTypeEndPoint + "/GetQuestionTypeById";



        public static string? ChoiceEndPoint = baseUrl + "/Choice";

        //public static string? GetChoiceEndPoint = ChoiceEndPoint + "/Get";

        public static string? GetChoiceByQuestionIdEndPoint = ChoiceEndPoint + "/GetChoiceByQuestionId";

        //public static string? GetChoiceByIdEndPoint = ChoiceEndPoint + "/GetChoiceById";

        public static string? CreateChoiceEndPoint = ChoiceEndPoint + "/Create";

        public static string? DeleteChoiceEndPoint = ChoiceEndPoint + "/Delete";

        //public static string? UpdateChoiceEndPoint = ChoiceEndPoint + "/Update";
    }
}
