namespace Brilliance.API.Command
{
    internal record AddUserCommand : IRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }

        internal class AddUserCommandHandler : IRequestHandler<AddUserCommand>
        {
            private readonly IAccountService _accountService;
            private readonly IPasswordHasher _passwordHasher;
            public AddUserCommandHandler(IAccountService accountService, IPasswordHasher passwordHasher)
            {
                _accountService = accountService;
                _passwordHasher = passwordHasher;
            }
            public async Task Handle(AddUserCommand request, CancellationToken cancellationToken)
            {
                await _accountService.AddUser(new User
                {
                    Username = request.Username,
                    Password = _passwordHasher.HashPassword(request.Password),
                    RoleId = request.RoleId
                }, cancellationToken);
            }
        }
    }
}
