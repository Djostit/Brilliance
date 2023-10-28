using Brilliance.API.Services.Interfaces;

namespace Brilliance.API.Commands.DeleteEntity
{
    internal class DeleteCommentByIdCommandHandlerValidator : AbstractValidator<DeleteEntityByIdCommand<Comment>>
    {
        public DeleteCommentByIdCommandHandlerValidator(IRepository<Comment> repository)
        {
            RuleFor(x => x.Id)
                .MustAsync(repository.ExistId)
                .WithMessage("Комментария с таким номером нет");
        }
    }
    internal class DeleteCommentByIdCommandHandler : DeleteEntityByIdCommandHandler<Comment>
    {
        public DeleteCommentByIdCommandHandler(IRepository<Comment> repository) : base(repository)
        {
        }
    }
}
