using Brilliance.API.Services.Interfaces;

namespace Brilliance.API.Query
{
    internal record AuthorizationQuery : IRequest<string>
    {
        public string Username { get; set; }
        public string Password { get; set; }
        internal class AuthorizationQueryHanlder : IRequestHandler<AuthorizationQuery, string>
        {
            private readonly ITokenService _tokenService;
            private readonly IAccountService _accountService;
            public AuthorizationQueryHanlder(ITokenService tokenService, IAccountService accountService)
            {
                _tokenService = tokenService;
                _accountService = accountService;
            }
            public async Task<string> Handle(AuthorizationQuery request, CancellationToken cancellationToken)
                => _tokenService.GenerateJwtToken(request.Username,
                    await _accountService.Authorization(request.Username, cancellationToken));
        }
    }
}
