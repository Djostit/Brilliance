using Brilliance.API.Client;
using Microsoft.AspNetCore.Authentication.Cookies;
using Refit;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/SignIn";
        options.LogoutPath = "/Account/SignOut";
        options.AccessDeniedPath = "/Home/AccessDenied";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
        options.Cookie.Name = Guid.NewGuid().ToString();
    });
builder.Services.AddRouting(options =>
{
    options.LowercaseUrls = true;
    options.LowercaseQueryStrings = true; 
});

builder.Services.AddAuthorization();

builder.Services.AddControllersWithViews();

builder.Services.AddRefitClient<IPost>()
    .ConfigureHttpClient(b => b.BaseAddress = new Uri("http://localhost:10000/api/v1/posts"));

builder.Services.AddRefitClient<IUser>()
    .ConfigureHttpClient(b => b.BaseAddress = new Uri("http://localhost:1000/api/v1/users"));

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

app.Run();