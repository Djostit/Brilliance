namespace Brilliance.API.Queris.Another
{
    internal record AuthorizationQuery(string Username, string Password) : IRequest<string>;
    internal class AuthorizationQueryValidator : AbstractValidator<AuthorizationQuery>
    {
        public AuthorizationQueryValidator(IUserService userService)
        {
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("Обязательно")
                .MustAsync(userService.IsExistsUsername).WithMessage("Неверный никнейм");
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Обязательно");
            RuleFor(x => x)
                .MustAsync(async (value, cancel) => await userService.Authorization(value.Username, value.Password, cancel))
                .WithMessage("Неверный никнейм или пароль");
        }
    }
    internal class AuthorizationQueryHanlder : IRequestHandler<AuthorizationQuery, string>
    {
        private readonly ITokenService _tokenService;
        private readonly IUserService _accountService;
        public AuthorizationQueryHanlder(ITokenService tokenService, IUserService accountService)
        {
            _tokenService = tokenService;
            _accountService = accountService;
        }
        public async Task<string> Handle(AuthorizationQuery request, CancellationToken cancellationToken)
            => _tokenService.GenerateJwtToken(await _accountService.GetUserId(request.Username, cancellationToken),
                await _accountService.GetUserRole(request.Username, cancellationToken));
    }
}
