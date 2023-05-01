using Entity.Domain.ExamStudent;
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

        public List<ExamStudent> GetExams(int? id)
        {
            List<ExamStudent> exams = new List<ExamStudent>();
            ExamStudent exam;

            var data = GetExamDetailsFromDb(id);

            foreach (DataRow row in data.Rows)
            {
                exam = new ExamStudent
                {
                    ExamId = Convert.ToInt32(row["ExamId"]),
                    StudentId = Convert.ToInt32(row["StudentId"]),
                   // StartDate = Convert.ToDateTime(row["StartDate"]),
                    //EndDate = Convert.ToDateTime(row["EndDate"]),
                    //IsEnded = row["IsEnded"].ToString()
                };
                exams.Add(exam);
            }
            return exams;
        }

        private DataTable GetExamDetailsFromDb(int? id)
        {
            var query = "SELECT * FROM ExamStudent ES INNER JOIN Exam E ON ES.ExamId = E.ID" +
                "  where E.ID = " + id;
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

        //public List<ProductForGraph> GetProductsForGraph()
        //{
        //    List<ProductForGraph> productsForGraph = new List<ProductForGraph>();
        //    ProductForGraph productForGraph;

        //    var data = GetProductsForGraphFromDb();

        //    foreach (DataRow row in data.Rows)
        //    {
        //        productForGraph = new ProductForGraph
        //        {
        //            Category = row["Category"].ToString(),
        //            Products = Convert.ToInt32(row["Products"])
        //        };
        //        productsForGraph.Add(productForGraph);
        //    }

        //    return productsForGraph;
        //}

        //private DataTable GetProductsForGraphFromDb()
        //{
        //    var query = "SELECT Category, COUNT(Id) Products FROM Product GROUP BY Category";
        //    DataTable dataTable = new DataTable();

        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        try
        //        {
        //            connection.Open();
        //            using (SqlCommand command = new SqlCommand(query, connection))
        //            {
        //                using (SqlDataReader reader = command.ExecuteReader())
        //                {
        //                    dataTable.Load(reader);
        //                }
        //            }

        //            return dataTable;
        //        }
        //        catch (Exception ex)
        //        {
        //            throw;
        //        }
        //        finally
        //        {
        //            connection.Close();
        //        }
        //    }
        //}
    }
}
