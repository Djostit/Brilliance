using Brilliance.API.Client;
using Microsoft.AspNetCore.Authentication.Cookies;
using Refit;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(options =>
        {
            options.LoginPath = "/Account/SignIn";
            options.AccessDeniedPath = "/Account/AccessDenied";
        });

builder.Services.AddAuthorization();

builder.Services.AddControllersWithViews();

builder.Services.AddRefitClient<IBrilliance>()
    .ConfigureHttpClient(b => b.BaseAddress = new Uri("http://localhost:10000"));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapFallbackToFile("/Account/AccessDenied");

app.Run();