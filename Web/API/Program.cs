using Abstraction.Service.Choice;
using Abstraction.Service.Course;
using Abstraction.Service.ExamStudent;
using Abstraction.Service.Exam;
using Abstraction.Service.Question;
using Abstraction.Service.QuestionType;
using Abstraction.Service.Student;
using API.Filters;
using DataAccess.Data;
using Service.Choice;
using Service.Course;
using Service.ExamStudent;
using Service.Exam;
using Service.Question;
using Service.QuestionType;
using Service.Student;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IExamStudentService, ExamStudentService>();
builder.Services.AddScoped<IExamService, ExamService>();
builder.Services.AddScoped<IQuestionService, QuestionService>();
builder.Services.AddScoped<IQuestionTypeService, QuestionTypeService>();
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


