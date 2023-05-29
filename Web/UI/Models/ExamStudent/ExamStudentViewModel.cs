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
}
