namespace Entity.Dto.ExamUser
{
	public class ExamUserDto:BaseEntityDto.BaseEntityDto
	{
		public int ExamId { get; set; }
		public int UserName { get; set; }	

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
