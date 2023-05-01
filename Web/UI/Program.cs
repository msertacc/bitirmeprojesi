using DataAccess.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Abstraction.Service.Course;
using Abstraction.Service.Student;
using Service.Course;
using Service.Student;
using Abstraction.Service.ExamStudent;
using Service.ExamStudent;
using UI.SignalR.Hubs;
using UI.SignalR.SubscribeTableDependicies;
using UI.SignalR.MiddlewareExtensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultUI()
            .AddDefaultTokenProviders();
//builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<IExamStudentService, ExamStudentService>();
builder.Services.AddScoped<IStudentService, StudentService>();
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
    pattern: "{controller=Exam}/{action=Index}/{id?}");
app.MapRazorPages();

//using (var scope = app.Services.CreateScope())
//{
//    await DbSeeder.SeedRolesAndAdminAsync(scope.ServiceProvider);
//}
app.UseSqlTableDependency<SubscribeExamTableDependency>(connectionString);
app.Run();
