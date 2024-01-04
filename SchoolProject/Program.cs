using DemoEFApp.Context;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Repository;
using SchoolProject.Respository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IStudentRespository, StudentRespository>();
builder.Services.AddTransient<ITeacherRepository, TeacherRepository>();
builder.Services.AddTransient<IRoomRepository, RoomRepository>();
builder.Services.AddTransient<ICourseRepository, CourseRepository>();


var connectionString = builder.Configuration.GetConnectionString("MyConnection");
builder.Services.AddDbContext<MyContext>(options => options.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
