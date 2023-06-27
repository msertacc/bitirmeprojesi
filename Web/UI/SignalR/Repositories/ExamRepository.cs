using Entity.Domain.ExamUser;
using Microsoft.Data.SqlClient;
using System.Data;

namespace UI.SignalR.Repositories
{
    public class ExamRepository
    {
        string? connectionString;
        public ExamRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Exam> GetExams(int? id)
        {
            List<Exam> exams = new List<Exam>();
            Exam exam;

            var data = GetExamDetailsFromDb(id);

            foreach (DataRow row in data.Rows)
            {
                exam = new Exam
                {
                    Id = Convert.ToInt32(row["Id"]),
                    IsEnded = row["IsEnded"].ToString(),
                };
                exams.Add(exam);
            }
            return exams;
        }

        private DataTable GetExamDetailsFromDb(int? id)
        {
            var query = "SELECT * FROM Exam E where E.ID = " + id;
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            dataTable.Load(reader);
                        }
                    }

                    return dataTable;
                }
                catch (Exception ex)
                {
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}
