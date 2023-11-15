using Brilliance.API.Services.Interfaces;

namespace Brilliance.API.Commands.EditEntity
{
    internal record EditUserCommand(int? Id, string Username, string Password) : IRequest;
    internal class EditUserCommandHandler : IRequestHandler<EditUserCommand>
    {
        private readonly IUserService _service;
        public EditUserCommandHandler(IUserService service)
        {
            _service = service;
        }
        public async Task Handle(EditUserCommand request, CancellationToken cancellationToken)
        {
            await _service.UpdateUser(new User
            {
                Id = (int)request.Id,
                Username = request.Username,
                Password = request.Password
            }, cancellationToken);
        }
    }
    internal class EditUserCommandValidator : AbstractValidator<EditUserCommand> 
    {
        public EditUserCommandValidator(IUserService userService)
        {
            RuleFor(x => x.Username)
                .NotEmpty()
                .WithMessage("Обязательно")
                .MinimumLength(4)
                .WithMessage("Короткий")
                .MaximumLength(16)
                .WithMessage("Длинный");

            RuleFor(x => x)
                .MustAsync(async (value, cancel) => await userService.IsExistsSelfUsername((int)value.Id, value.Username, cancel))
                .WithName("Username")
                .WithMessage("Никнейм занят");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Обязательно");
        }
    }
}
