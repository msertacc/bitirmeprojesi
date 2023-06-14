using Abstraction.Service.AnswerOfQuestionService;
using Abstraction.Service.Course;
using Abstraction.Service.ExamUser;
using Abstraction.Service.StudentCourse;
using Abstraction.Service.User;
using DataAccess.Data;
using Entity.Domain.ApplicationUser;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Service.AnswerOfQuestion;
using Service.Course;
using Service.ExamUser;
using Service.StudentCourse;
using Service.User;
using System.Globalization;
using UI.SignalR.Hubs;
using UI.SignalR.MiddlewareExtensions;
using UI.SignalR.SubscribeTableDependicies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var cultureInfo = new CultureInfo("tr-TR");
CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

//builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultUI()
            .AddDefaultTokenProviders();
builder.Services.AddScoped<IAnswerOfQuestionService, AnswerOfQuestionService>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<IExamUserService, ExamUserService>();
builder.Services.AddScoped<IStudentCourseService, StudentCourseService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<HttpClient>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddSignalR();
builder.Services.AddSingleton<ExamHub>();
builder.Services.AddSingleton<SubscribeExamTableDependency>();

var app = builder.Build();
var connectionString = app.Configuration.GetConnectionString("ApplicationDbContextConnection");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for Courseion scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.MapHub<ExamHub>("/examHub");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=User}/{action=Index}/{id?}");
app.MapRazorPages();

//app.UseSqlTableDependency<SubscribeExamTableDependency>(connectionString);
app.Run();
