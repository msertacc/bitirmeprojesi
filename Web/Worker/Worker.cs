using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Service.Worker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly string? _connectionString;
        public Worker(ILogger<Worker> logger, IConfiguration? configuration)
        {
            _logger = logger;
            _connectionString = configuration?.GetConnectionString("ApplicationDbContextConnection")?.ToString();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            string query = "UPDATE Exam SET IsEnded = 1 WHERE EndDate <= GETDATE()";
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
            }
            catch
            {
                throw;
            }

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                command.ExecuteNonQuery();
                await Task.Delay(5000, stoppingToken);

            }
        }

        
    }
}