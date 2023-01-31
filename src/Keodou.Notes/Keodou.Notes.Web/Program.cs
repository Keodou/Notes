using Keodou.Notes.Web.Data;
using Keodou.Notes.Web.Models;
using Keodou.Notes.Web.Models.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Service container
builder.Services.AddDbContext<NotesDbContext>(d => d.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
    ));
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<UserRepository>();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options => options.LoginPath = "/Account/Login");
builder.Services.AddAuthorization();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

//SeedData.EnsurePopulated();
app.MapControllerRoute(
    name: "User",
    pattern: "{area:exists}/{controller=Home}/{action=Notes}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=WelcomePage}/{id?}");

app.Run();