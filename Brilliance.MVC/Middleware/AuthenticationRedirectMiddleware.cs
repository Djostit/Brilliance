namespace Brilliance.MVC.Middleware
{
    public class AuthenticationRedirectMiddleware
    {
        private readonly RequestDelegate _next;
        public AuthenticationRedirectMiddleware(RequestDelegate next)
            => _next = next;

        public async Task Invoke(HttpContext context)
        {
            await _next(context);

            // Проверяем, что текущий код состояния - 401 (Unauthorized)
            if (context.Response.StatusCode == StatusCodes.Status401Unauthorized)
            {
                // Пользователь не аутентифицирован, выполняем перенаправление
                context.Response.Redirect("/Account/SignIn");
            }
        }
    }
}
