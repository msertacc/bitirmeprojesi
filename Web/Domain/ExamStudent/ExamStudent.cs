using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Entity.Domain.ExamStudent
{

    [Table("ExamStudent")]
    public class ExamStudent:BaseEntity.BaseEntity
    {
        public int Id { get; set; }
        public int ExamId { get; set; }
        public int StudentId { get; set; }
		//public DateTime StartDate { get; set; }
		//public DateTime EndDate { get; set; }
		//public string? IsEnded { get; set; }
	}

    [Table("Exam")]
    public class Exam 
    {
        public int? Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? IsEnded { get; set; }
    }
}
