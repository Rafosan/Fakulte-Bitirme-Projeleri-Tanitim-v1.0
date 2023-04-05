using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("MyDbConnection");
builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseSqlServer(connectionString));
//burada da servislere eklemen lazým repositoryi
builder.Services.AddScoped(typeof(IGenericDal<>), typeof(GenericRepository<>));
//builder.Services.AddScoped(typeof(IGenericService<About>), typeof(AboutManager));
//builder.Services.AddScoped(typeof(IGenericService<Admin>), typeof(AdminManager));
//builder.Services.AddScoped(typeof(IGenericService<Project>), typeof(ProjectManager));
//builder.Services.AddScoped(typeof(IGenericService<Student>), typeof(StudentManager));
//builder.Services.AddScoped(typeof(IGenericService<Teacher>), typeof(TeacherManager));
//builder.Services.AddScoped(typeof(EfStudentDal), typeof(GenericRepository<Student>));
//builder.Services.AddScoped(typeof(EfAboutDal), typeof(GenericRepository<About>));
//builder.Services.AddScoped(typeof(EfAdminDal), typeof(GenericRepository<Admin>));
//builder.Services.AddScoped(typeof(EfTeacherDal), typeof(GenericRepository<Teacher>));
//builder.Services.AddScoped(typeof(EfProjectDal), typeof(GenericRepository<Project>));
builder.Services.AddScoped<EfStudentDal>();
builder.Services.AddScoped<IStudentDal, EfStudentDal>();
builder.Services.AddScoped<IStudentService, StudentManager>();




builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
