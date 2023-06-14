using Microsoft.Data.SqlClient;

namespace Service.Worker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly string? _connectionString;

        public Worker(ILogger<Worker> logger, IConfiguration configuration)
        {
            _logger = logger;
            _connectionString = configuration.GetConnectionString("ApplicationDbContextConnection");
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            const string query = "UPDATE Exam SET IsEnded = 1 WHERE ExamEndTime <= GETDATE()";
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync(stoppingToken);
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        await command.ExecuteNonQueryAsync(stoppingToken);
                    }
                }
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
