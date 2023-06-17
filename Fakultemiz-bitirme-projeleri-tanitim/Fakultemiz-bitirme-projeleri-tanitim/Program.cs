using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("MyDbConnection");
builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseSqlServer(connectionString));
//burada da servislere eklemen lazým repositoryi
builder.Services.AddScoped(typeof(IGenericDal<>), typeof(GenericRepository<>));
builder.Services.AddScoped<EfStudentDal>();
builder.Services.AddScoped<IStudentDal, EfStudentDal>();
builder.Services.AddScoped<IStudentService, StudentManager>();
builder.Services.AddScoped<EfProjectDal>();
builder.Services.AddScoped<IProjectDal, EfProjectDal>();
builder.Services.AddScoped<IProjectService, ProjectManager>();
builder.Services.AddScoped<EfAdminDal>();
builder.Services.AddScoped<IAdminDal, EfAdminDal>();
builder.Services.AddScoped<IAdminService, AdminManager>();
builder.Services.AddScoped<EfTeacherDal>();
builder.Services.AddScoped<ITeacherDal, EfTeacherDal>();
builder.Services.AddScoped<ITeacherService, TeacherManager>();
builder.Services.AddScoped<EfCategoryDal>();
builder.Services.AddScoped<ICategoryDal, EfCategoryDal>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();

builder.Services.AddControllersWithViews();

builder.Services.AddSession();//Ben yazdým session için

//builder.Services.AddMvc(config =>
//{
//    var policy = new AuthorizationPolicyBuilder()
//                    .RequireAuthenticatedUser()
//                    .Build();
//    config.Filters.Add(new AuthorizeFilter(policy));
//});

//builder.Services.AddMvc();
//builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
//    .AddCookie(options =>
//    {
//        options.LoginPath = "/Login/Index";
//    });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePages();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSession();//Session kullanmak için

app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
