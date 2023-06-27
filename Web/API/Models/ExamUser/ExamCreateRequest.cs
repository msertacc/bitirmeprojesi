namespace API.Models.ExamUser
{
    public class ExamUserUpdateRequest
    {
        public int? ExamId { get; set; }
        public Guid? UserId { get; set; }
    }
}
