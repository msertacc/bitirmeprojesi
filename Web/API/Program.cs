using Abstraction.Service.Choice;
using Abstraction.Service.Course;
using Abstraction.Service.ExamUser;
using Abstraction.Service.Exam;
using Abstraction.Service.Question;
using Abstraction.Service.User;
using API.Filters;
using DataAccess.Data;
using Service.Choice;
using Service.Course;
using Service.ExamUser;
using Service.Exam;
using Service.Question;
using Service.User;
using System.Globalization;
using Abstraction.Service.AnswerOfQuestionService;
using Service.AnswerOfQuestion;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var cultureInfo = new CultureInfo("tr-TR");
CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<IAnswerOfQuestionService, AnswerOfQuestionService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IExamUserService, ExamUserService>();
builder.Services.AddScoped<IExamService, ExamService>();
builder.Services.AddScoped<IQuestionService, QuestionService>();
builder.Services.AddScoped<IChoiceService, ChoiceService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddMvc((options) =>
{
	options.Filters.Add(typeof(ExceptionFilter));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


