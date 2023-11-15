using Brilliance.API.Services.Interfaces;

namespace Brilliance.API.Commands.DeleteEntity
{
    internal record DeleteUserCommand(int Id) : IRequest;
    internal class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly IUserService _service;
        public DeleteUserCommandHandler(IUserService service)
        {
            _service = service;
        }
        public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            await _service.DeleteUser(request.Id, cancellationToken);
        }
    }
    internal class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand> 
    {
        public DeleteUserCommandValidator(IUserService userService)
        {
            RuleFor(x => x.Id)
                .MustAsync(userService.IsExists)
                .WithMessage("Такого пользователя нет");
        }
    }
}
