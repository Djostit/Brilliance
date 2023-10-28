using Brilliance.API.Behavior;
using Brilliance.API.Extensions;
using Brilliance.API.Middleware;
using Brilliance.API.Services;
using Brilliance.API.Services.Interfaces;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BrillianceContext>(opt =>
{
    var conn = builder.Configuration.GetConnectionString("LocalConnection");
    opt.UseMySql(conn, ServerVersion.AutoDetect(conn));
});

builder.Services
    .AddScoped<IPasswordHasher, PasswordHasher>()
    .AddScoped<ITokenService, TokenService>()
    .AddScoped<IAccountService, AccountService>()
    .AddScoped(typeof(IRepository<>), typeof(Repository<>));

builder.Services.AddMediatR(c => c.RegisterServicesFromAssemblyContaining<Program>());

builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly(), includeInternalTypes: true);
builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));

builder.Services.ConfigureJwtAuthentication(builder.Configuration.GetSection("JwtSettings").Get<JwtSettings>());

builder.Services.AddMapster();

var app = builder.Build();

app.UseMiddleware<ErrorHandlingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();