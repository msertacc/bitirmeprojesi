namespace Entity.Dto.AnswerOfQuestion
{
    public class AnswerOfQuestionDto : BaseEntityDto.BaseEntityDto
    {
        public List<AnswerDto> AnswerList { get; set; }
        public int? ExamId { get; set; }
        public Guid? UserId { get; set; }
    }

    public class AnswerDto
    {
        public int? ChoiceId { get; set; }
        public int? QuestionId { get; set; }
    }
}
