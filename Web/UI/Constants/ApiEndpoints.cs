namespace UI.Constants
{
	public static class ApiEndpoints
	{
		public static string? baseUrl = "https://localhost:44358";

		public static string? WeatherForecast = baseUrl + "/WeatherForecast";

		public static string? WeatherForecastGet = WeatherForecast + "";
        #region Course
        public static string? CourseEndPoint = baseUrl + "/Course";

		public static string? GetCourseEndPoint = CourseEndPoint + "/Get";

        public static string? GetCourseByGuidEndPoint = CourseEndPoint + "/GetCoursesByGuid";


        public static string? GetCourseByIdEndPoint = CourseEndPoint + "/GetById";

		public static string? CreateCourseEndPoint = CourseEndPoint + "/Create";

		public static string? UpdateCourseEndPoint = CourseEndPoint + "/Update";

		public static string? DeleteCourseEndPoint = CourseEndPoint + "/Delete";
		#endregion
		#region User
		public static string? UserEndPoint = baseUrl + "/User";

		public static string? GetUserEndPoint = UserEndPoint + "/Get";

		public static string? GetUserByIdEndPoint = UserEndPoint + "/GetById";

        public static string? UpdateUserVerifyEndPoint = UserEndPoint + "/UpdateUserVerify";  

        public static string? CreateUserEndPoint = UserEndPoint + "/Create";

		public static string? UpdateUserEndPoint = UserEndPoint + "/Update";

		public static string? DeleteUserEndPoint = UserEndPoint + "/Delete";

		public static string? GetUserByGuidEndPoint = UserEndPoint + "/GetUserByGuid";

		#endregion
		#region ExamUser
		public static string? ExamUserEndPoint = baseUrl + "/ExamUser";

        public static string? GetExamUserByIdEndPoint = ExamUserEndPoint + "/GetExamByUserId";

        public static string? CreateExamUser = ExamUserEndPoint + "/Create";

        public static string? UpdateExamUser = ExamUserEndPoint + "/Update";

        public static string? GetResultsForExams = ExamUserEndPoint + "/GetResultsForExamsByUserId";
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

        public static string? ChoiceEndPoint = baseUrl + "/Choice";

        //public static string? GetChoiceEndPoint = ChoiceEndPoint + "/Get";

        public static string? GetChoiceByQuestionIdEndPoint = ChoiceEndPoint + "/GetChoiceByQuestionId";

        public static string? GetChoicesByQuestionIdListEndPoint = ChoiceEndPoint + "/GetChoicesByQuestionIdList";

        //public static string? GetChoiceByIdEndPoint = ChoiceEndPoint + "/GetChoiceById";

        public static string? CreateChoiceEndPoint = ChoiceEndPoint + "/Create";

        public static string? DeleteChoiceEndPoint = ChoiceEndPoint + "/Delete";

        //public static string? UpdateChoiceEndPoint = ChoiceEndPoint + "/Update";

        public static string? AnswerOfQuestion = baseUrl + "/AnswerOfQuestion";

        public static string? CreateAnswerOfQuestionEndPoint = AnswerOfQuestion + "/Create";


        public static string? StudentCourse = baseUrl + "/StudentCourse";

        public static string? GetStudentCourseEndPoint = StudentCourse + "/Get";

		public static string? GetStudentCourseByUserIdEndPoint = StudentCourse + "/GetStudentCourseByUserId";

		public static string? GetStudentCourseByIdEndPoint = StudentCourse + "/GetById";

		public static string? CreateStudentCourseEndPoint = StudentCourse + "/Create";

		public static string? DeleteStudentCourseEndPoint = StudentCourse + "/Delete";



	}
}
