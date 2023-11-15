using Brilliance.API.Services.Interfaces;

namespace Brilliance.API.Commands.AddEntity
{
    internal record AddUserCommand(string Username, string Password) : IRequest;
    internal class AddUserCommandHandler : IRequestHandler<AddUserCommand>
    {
        private readonly IUserService _userService;
        private readonly IPasswordHasher _passwordHasher;
        public AddUserCommandHandler(IUserService userService, IPasswordHasher passwordHasher)
        {
            _userService = userService;
            _passwordHasher = passwordHasher;
        }
        public async Task Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            await _userService.CreateUser(new User
            {
                Username = request.Username,
                Password = _passwordHasher.HashPassword(request.Password)
            }, cancellationToken);
        }
    }
    internal class AddUserCommandValidator : AbstractValidator<AddUserCommand>
    {
        public AddUserCommandValidator(IUserService userService)
        {
            RuleFor(x => x.Username)
                .NotEmpty()
                .WithMessage("Обязательно")
                .MinimumLength(4)
                .WithMessage("Короткий")
                .MaximumLength(16)
                .WithMessage("Длинный")
                .MustAsync(userService.IsExistsUsername)
                .WithMessage("Никнейм занят");
            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Обязательно");
        }
    }
}
