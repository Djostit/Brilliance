using Brilliance.MVC.Middleware;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(options =>
        {
            options.LoginPath = "/Account/SignIn"; // ���� � �������� �����
            options.AccessDeniedPath = "/Account/AccessDenied"; // ���� � �������� � ������� � �������
        });

builder.Services.AddAuthorization();

builder.Services.AddControllersWithViews();


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseMiddleware<AuthenticationRedirectMiddleware>();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();