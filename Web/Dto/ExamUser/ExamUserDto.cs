namespace Entity.Dto.ExamUser
{
	public class ExamUserDto:BaseEntityDto.BaseEntityDto
	{
		public int ExamId { get; set; }
        public Guid UserId { get; set; }
        public int UserName { get; set; }
        public string IsEnded { get; set; }
        public string IsEndedByUser { get; set; }
        public DateTime? ExamEndTime { get; set; }
        public DateTime? ExamStartTime { get; set; }
        public string ExamName { get; set; }

    }

    public class ResultExamDto
    {
        public string ExamEndTime { get; set; }
        public string ExamStartTime { get; set; }
        public string ExamName { get; set; }
        public string CourseName { get; set; }
        public int? Score { get; set; }
    }
}
