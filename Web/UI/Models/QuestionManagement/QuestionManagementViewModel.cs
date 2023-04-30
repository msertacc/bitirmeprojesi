using Entity.Domain.BaseEntity;
using UI.Models.Choice;
using UI.Models.Question;
using UI.Models.QuestionType;

namespace UI.Models.QuestionManagement
{
    public class QuestionManagementViewModel : BaseEntity
    {
        public List<QuestionTypeViewModel> QuestionTypeList { get; set; }
        public QuestionViewModel QuestionModel { get; set; }
        public List<ChoiceViewModel> ChoiceList { get; set; }
    }
}
