using TableDependency.SqlClient;
using UI.SignalR.Hubs;
using Entity.Domain.ExamUser;

namespace UI.SignalR.SubscribeTableDependicies
{
    public class SubscribeExamTableDependency : ISubscribeTableDependency
    {
        SqlTableDependency<Exam> tableDependency;
        ExamHub examHub;

        public SubscribeExamTableDependency(ExamHub examHub)
        {
            this.examHub = examHub;
        }

        public void SubscribeTableDependency(string connectionString)
        {
            tableDependency = new SqlTableDependency<Exam>(connectionString);
            tableDependency.OnChanged += TableDependency_OnChanged;
            tableDependency.OnError += TableDependency_OnError;
            tableDependency.Start();
        }

        private void TableDependency_OnChanged(object sender, TableDependency.SqlClient.Base.EventArgs.RecordChangedEventArgs<Exam> e)
        {
            if (e.ChangeType != TableDependency.SqlClient.Base.Enums.ChangeType.None)
            {
                examHub?.SendExams(e.Entity.Id);
            }
        }

        private void TableDependency_OnError(object sender, TableDependency.SqlClient.Base.EventArgs.ErrorEventArgs e)
        {
            Console.WriteLine($"{nameof(ExamUser)} SqlTableDependency error: {e.Error.Message}");
        }
    }
}
