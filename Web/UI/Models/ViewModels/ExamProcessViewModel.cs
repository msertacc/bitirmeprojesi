using UI.Models.Choice;
using UI.Models.Exam;
using UI.Models.ExamUser;
using UI.Models.Question;

namespace UI.Models.ViewModels
{
    public class ExamProcessViewModel
    {
        public List<QuestionViewModel>? Question { get; set; }
        public List<ChoiceViewModel>? Choice { get; set; }
        public ExamViewModel? Exam { get; set; }
    }

	public class UserExamViewModel
	{
        public List<ExamUserViewModel>? ExamUserList { get; set; }
		public List<ExamViewModel>? ExamList { get; set; }
	}


}
