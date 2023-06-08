using Entity.Domain.BaseEntity;

namespace UI.Models.ExamUser
{
	public class ExamUserViewModel:BaseEntity
	{
        public int ExamId { get; set; }
        public int UserName { get; set; }
		public string IsEnded { get; set; }
        //public DateTime EndDate { get; }
		//public DateTime StartDate { get; }
	}

    public class ResultExam
    {
        public int? ExamId { get; set; }
		public string ExamStartTime { get; set; }
		public string ExamEndTime { get; set; }
		public string ExamName { get; set; }
		public string CourseName { get; set; }
		public int? Score { get; set; }
    }
}
