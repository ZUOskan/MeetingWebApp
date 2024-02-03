using MeetingApp.BusinessLogic.LogicServices;
using MeetingApp.DataAccess.DataContext;
using MeetingApp.DataAccess.DataServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MeetingApp.Data;
using MeetingApp.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("MeetingAppContextConnection") ?? throw new InvalidOperationException("Connection string 'MeetingAppContextConnection' not found.");

builder.Services.AddDbContext<MeetingAppContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<MeetingAppContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IMeetingsLogic, MeetingsLogic>();
builder.Services.AddSingleton<IMeetingsDataAccess, MeetingsDataAccess>();
builder.Services.AddSingleton<IDapperOrmHelper, DapperOrmHelper>();
builder.Services.AddRazorPages();





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
app.MapRazorPages();
app.Run();
