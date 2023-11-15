using Brilliance.API.Behavior;
using Brilliance.API.Extensions;
using Brilliance.API.Middleware;
using Brilliance.API.Services;
using Brilliance.API.Services.Interfaces;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

Host.CreateDefaultBuilder(args)
    .ConfigureWebHostDefaults(webBuilder =>
    {
        webBuilder.UseKestrel();
        webBuilder.UseUrls("http://+:80");
        webBuilder.UseStartup<Program>();
    });

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BrillianceContext>(opt =>
{
    var conn = builder.Configuration.GetConnectionString("DefaultConnection");
    opt.UseMySql(conn, ServerVersion.AutoDetect(conn));
});

builder.Services
    .AddScoped<IPasswordHasher, PasswordHasher>()
    .AddScoped<ITokenService, TokenService>()
    .AddScoped<IUserService, UserService>();

builder.Services.AddMediatR(c => c.RegisterServicesFromAssemblyContaining<Program>());

builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly(), includeInternalTypes: true);
builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));

builder.Services.ConfigureJwtAuthentication(builder.Configuration.GetSection("JwtSettings").Get<JwtSettings>());

builder.Services.AddMapster();

var app = builder.Build();

app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();