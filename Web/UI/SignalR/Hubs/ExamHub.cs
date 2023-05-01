using Microsoft.AspNetCore.SignalR;
using UI.SignalR.Repositories;

namespace UI.SignalR.Hubs
{
    public class ExamHub : Hub
    {
        ExamRepository examRepository;

        public ExamHub(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ApplicationDbContextConnection");
            examRepository = new ExamRepository(connectionString);
        }

        public async Task SendExams(int? id)
        {
            var exams = examRepository.GetExams(id);
            await Clients.All.SendAsync("ReceivedExams", exams);
        }
    }
}
