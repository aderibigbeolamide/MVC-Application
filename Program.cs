using Microsoft.AspNetCore.Authentication.Cookies;
using MVCVottingApp;
using MVCVottingApp.Data;
using MVCVottingApp.Implementation.Repository;
using MVCVottingApp.Implementation.Services;
using MVCVottingApp.Interface.Repository;
using MVCVottingApp.Interface.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAuthentication
    (CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(config =>
{
    config.LoginPath = "/MVCVottingApp/AdminLogin";
    config.LoginPath = "/MVCVottingApp/StudentLogin";
    config.Cookie.Name = "MVCVottingApp";
    config.LogoutPath = "/MVCVottingApp/Logout";
});
builder.Services.AddAuthentication();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<MVCVottingAppContext>();
builder.Services.AddSession();
builder.Services.AddScoped<IElectoralOfficerService, ElectoralOfficerService>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IPositionService, PositionService>();
builder.Services.AddScoped<IContestantService, ContestantService>();
builder.Services.AddScoped<IVoteService, VoteService>();
builder.Services.AddScoped<IVoterService, VoterService>();

// Add Repository to the container.
builder.Services.AddScoped<IElectoralOfficerRepository, ElectoralOfficerRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IPositionRepository, PositionRepository>();
builder.Services.AddScoped<IContestantRepository, ContestantRepository>();
builder.Services.AddScoped<IVoteRepository, VoteRepository>();
builder.Services.AddScoped<IVoterRepository, VoterRepository>();



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
app.UseAuthentication();
app.UseAuthorization();
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

