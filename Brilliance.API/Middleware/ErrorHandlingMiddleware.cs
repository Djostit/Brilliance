using Microsoft.AspNetCore.Mvc.Infrastructure;
using Newtonsoft.Json;

namespace Brilliance.API.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ProblemDetailsFactory _problemDetailsFactory;
        public ErrorHandlingMiddleware(RequestDelegate next, ProblemDetailsFactory problemDetailsFactory)
        {
            _next = next;
            _problemDetailsFactory = problemDetailsFactory;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ValidationException ex)
            {
                var problemDetails = _problemDetailsFactory.CreateProblemDetails(
                    context,
                    400,
                    title: "Ошибка валидации",
                    detail: "Произошла одна или несколько ошибок валидации");
                problemDetails.Extensions["errors"] = ex.Errors
                    .Select(e => new { e.PropertyName, e.ErrorMessage }).ToList();

                context.Response.ContentType = "application/problem+json";
                context.Response.StatusCode = 400;

                await context.Response.WriteAsync(JsonConvert.SerializeObject(problemDetails));
            }
            catch (Exception ex)
            {
                var problemDetails = _problemDetailsFactory.CreateProblemDetails(
                    context,
                    500,
                    title: "Внутренняя ошибка",
                    detail: "Произошла внутренняя ошибка сервера");
                problemDetails.Extensions["message"] = ex.Message;

                context.Response.ContentType = "application/problem+json";
                context.Response.StatusCode = 500;

                await context.Response.WriteAsync(JsonConvert.SerializeObject(problemDetails));
            }
        }

    }
}
