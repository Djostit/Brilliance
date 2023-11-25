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
        options.ExpireTimeSpan = TimeSpan.FromHours(4);
        options.Cookie.Name = Guid.NewGuid().ToString();
    });
builder.Services.AddRouting(options =>
{
    options.LowercaseUrls = true;
    options.LowercaseQueryStrings = true; 
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins("http://localhost:81"));
});

builder.Services.AddAuthorization();

builder.Services.AddControllersWithViews();

builder.Services.AddRefitClient<IPostClient>()
    .ConfigureHttpClient(b => b.BaseAddress = new Uri("http://localhost/api/v1/posts"));

builder.Services.AddRefitClient<IUserClient>()
    .ConfigureHttpClient(b => b.BaseAddress = new Uri("http://localhost/api/v1/users"));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseCors("AllowSpecificOrigin");

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();