using Entity.Domain.BaseEntity;
using UI.Models.Choice;
using UI.Models.Question;

namespace UI.Models.QuestionManagement
{
    public class QuestionManagementViewModel : BaseEntity
    {
        public QuestionViewModel QuestionModel { get; set; }
        public List<ChoiceViewModel> ChoiceList { get; set; }
    }
}
