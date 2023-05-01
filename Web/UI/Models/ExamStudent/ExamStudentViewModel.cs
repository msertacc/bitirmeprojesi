using Entity.Domain.BaseEntity;

namespace UI.Models.ExamStudent
{
	public class ExamStudentViewModel:BaseEntity
	{
        public int ExamId { get; set; }
        public int StudentId { get; set; }
        //public DateTime EndDate { get; }
		//public DateTime StartDate { get; }
	}
}
