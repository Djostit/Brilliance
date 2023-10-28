using Brilliance.API.Services.Interfaces;

namespace Brilliance.API.Commands.DeleteEntity
{
    internal class DeletePostByIdCommandHandlerValidator : AbstractValidator<DeleteEntityByIdCommand<Post>>
    {
        public DeletePostByIdCommandHandlerValidator(IRepository<Post> repository)
        {
            RuleFor(x => x.Id)
                .MustAsync(repository.ExistId)
                .WithMessage("Поста с таким номером нет");
        }
    }
    internal class DeletePostByIdCommandHandler : DeleteEntityByIdCommandHandler<Post>
    {
        public DeletePostByIdCommandHandler(IRepository<Post> repository) : base(repository)
        {
        }
    }
}
