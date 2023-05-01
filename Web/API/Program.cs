using Abstraction.Service.Choice;
using Abstraction.Service.Course;
<<<<<<< HEAD
using Abstraction.Service.ExamStudent;
=======
using Abstraction.Service.Exam;
using Abstraction.Service.Question;
using Abstraction.Service.QuestionType;
>>>>>>> 463c0936687fa4a89dde18d8fe19f649fd2636c5
using Abstraction.Service.Student;
using API.Filters;
using DataAccess.Data;
using Microsoft.AspNetCore.Mvc.Filters;
using Service.Choice;
using Service.Course;
<<<<<<< HEAD
using Service.ExamStudent;
=======
using Service.Exam;
using Service.Question;
using Service.QuestionType;
>>>>>>> 463c0936687fa4a89dde18d8fe19f649fd2636c5
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
<<<<<<< HEAD
builder.Services.AddScoped<IExamStudentService, ExamStudentService>();
=======
builder.Services.AddScoped<IExamService, ExamService>();
builder.Services.AddScoped<IQuestionService, QuestionService>();
builder.Services.AddScoped<IQuestionTypeService, QuestionTypeService>();
builder.Services.AddScoped<IChoiceService, ChoiceService>();
>>>>>>> 463c0936687fa4a89dde18d8fe19f649fd2636c5
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


