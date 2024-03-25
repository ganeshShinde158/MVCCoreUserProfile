using Microsoft.EntityFrameworkCore;
using MVCCoreUserProfile.Models;
using MVCCoreUserProfile.Services.Implementations;
using MVCCoreUserProfile.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddSession(e =>
{
    e.IdleTimeout = TimeSpan.FromMinutes(10);

});

builder.Services.AddSession(options =>
{
    options.Cookie.IsEssential = true;
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;

});
builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.MinimumSameSitePolicy = SameSiteMode.None;
    options.HttpOnly = Microsoft.AspNetCore.CookiePolicy.HttpOnlyPolicy.None;
    options.Secure = CookieSecurePolicy.Always; // Ensure Secure is set to Always for HTTPS
});


builder.Services.AddDbContext<UserProfileDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyCon"));
});

builder.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddTransient<IDesignationService, DesignationService>();
builder.Services.AddTransient<ICityService, CityService>();
builder.Services.AddTransient<IGenderService, GenderService>();
builder.Services.AddTransient<IQualificationService, QualificationService>();
builder.Services.AddTransient<ITopicService, TopicService>();
builder.Services.AddTransient<ITopicContentService, TopicContentService>();
builder.Services.AddTransient<IContent_questionsService, Content_questionsService>();
builder.Services.AddTransient<IUserDetailsService, UserDetailsService>();
builder.Services.AddTransient<IExamService, ExamService>();













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
app.UseHttpsRedirection(); 

app.UseSession();


app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapAreaControllerRoute(
    name: "User",
    areaName: "User",
    pattern: "User/{controller}/{action}");
app.MapAreaControllerRoute(
    name: "Admin",
    areaName: "Admin",
    pattern: "Admin/{controller}/{action}");

//app.MapAreaControllerRoute(
//    name: "Admin",
//    areaName: "Admin",
//    pattern: "Admin/{controller=Cities}/{action=Index}/{id?}");

//app.MapAreaControllerRoute(
//    name: "Admin",
//    areaName: "Admin",
//    pattern: "Admin/{controller=Genders}/{action=Index}/{id?}");

//app.MapAreaControllerRoute(
//    name: "Admin",
//    areaName: "Admin",
//    pattern: "Admin/{controller=Qualification}/{action=Index}/{id?}");

//app.MapAreaControllerRoute(
//    name: "Admin",
//    areaName: "Admin",
//    pattern: "Admin/{controller=Topics}/{action=Index}/{id?}");

//app.MapAreaControllerRoute(
//    name: "Admin",
//    areaName: "Admin",
//    pattern: "Admin/{controller=Topic_contents}/{action=Index}/{id?}");

//app.MapAreaControllerRoute(
//    name: "Admin",
//    areaName: "Admin",
//    pattern: "Admin/{controller=Content_questions}/{action=Index}/{id?}");

//app.MapAreaControllerRoute(
//    name: "User",
//    areaName: "User",
//    pattern: "User/{controller=User}/{action=Index}/{id?}");

//app.MapAreaControllerRoute(
//    name: "User",
//    areaName: "User",
//    pattern: "User/{controller=User}/{action=Register}");

//app.MapAreaControllerRoute(
//    name: "User",
//    areaName: "User",
//    pattern: "User/{controller=UserLogin}/{action=Index}/{id?}");

//app.MapAreaControllerRoute(
//    name: "User",
//    areaName: "User",
//    pattern: "User/{controller=UserLogin}/{action=UserDashboard}/{id?}");

//app.MapAreaControllerRoute(
//    name: "User",
//    areaName: "User",
//    pattern: "User/{controller=}/{action}");







app.Run();
