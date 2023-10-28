using Brilliance.API.Services.Interfaces;
using Brilliance.Domain.Models.DTO;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace Brilliance.API.Commands.AddEntity
{
    internal class AddUserCommandHandlerValidator : AbstractValidator<AddEntityCommand<UserDTO, User>>
    {
        public AddUserCommandHandlerValidator(IRepository<User> repository)
        {
            RuleFor(x => x.Model.Username)
                .NotEmpty().WithName("Username").WithMessage("Никнейм не может быть пустым")
                .MustAsync(async (value, cancel) => !await repository.Items.AnyAsync(x => x.Username == value, cancel))
                .WithName("Username").WithMessage("Никнейм уже занят");

            RuleFor(x => x.Model.Password)
                .NotEmpty().WithName("Password").WithMessage("Пароль не может быть пустым");
        }
    }

    internal class AddUserCommandHandler : AddEntityCommandHandler<UserDTO, User>
    {
        public AddUserCommandHandler(IMapper mapper, IRepository<User> repository) : base(mapper, repository)
        {
        }
    }
}
