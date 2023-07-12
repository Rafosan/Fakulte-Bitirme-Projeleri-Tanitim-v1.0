using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.Repository;
using Fakultemiz_bitirme_projeleri_tanitim.Models;
using Fakultemiz_bitirme_projeleri_tanitim.Models.LoginV;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("MyDbConnection");
builder.Services.AddDbContext<MyDbContext>(options =>options.UseSqlServer(connectionString));
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

builder.Services.AddSession(options =>
{
    options.Cookie.IsEssential = true; 
    options.IdleTimeout = TimeSpan.FromMinutes(20);                                    
});
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
    options.LoginPath = "/Login/Index";
    options.SlidingExpiration = true;
});
builder.Services.AddAuthorization(options =>
{
    options.DefaultPolicy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
    options.AddPolicy(Roles.Admin, policy => policy.RequireRole(Roles.Admin));
    options.AddPolicy(Roles.Teacher, policy => policy.RequireRole(Roles.Teacher));
    options.AddPolicy(Roles.Student, policy => policy.RequireRole(Roles.Student));
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = "LoginScheme";
    options.DefaultChallengeScheme = "LoginScheme";
    options.DefaultSignInScheme = "LoginScheme";
})
.AddCookie("LoginScheme", options =>
{
    options.LoginPath = "/Login/Index";
});

builder.Services.AddControllersWithViews();
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseStatusCodePages();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseExceptionHandler("/Home/Error");

app.UseSession();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
});
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"); 


app.Use(async (context, next) =>
    {
        var session = context.Session;
        if (session != null && !session.IsAvailable)
        {
            context.Response.Redirect("/Home/Index");
            return;
        }
        await next();
    });
app.Run();
