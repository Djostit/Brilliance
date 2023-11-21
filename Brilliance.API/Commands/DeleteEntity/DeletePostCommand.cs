namespace Brilliance.API.Commands.DeleteEntity
{
    internal record DeletePostCommand(int Id) : IRequest;
    internal class DeletePostCommandValidator : AbstractValidator<DeletePostCommand>
    {
        public DeletePostCommandValidator(IPostService postService)
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Обязательно")
                .MustAsync(postService.IsExists).WithMessage("Такого поста нет");
        }
    }
    internal class DeletePostCommandHandler : IRequestHandler<DeletePostCommand>
    {
        private readonly IPostService _service;
        public DeletePostCommandHandler(IPostService service)
        {
            _service = service;
        }
        public async Task Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            await _service.DeletePost(request.Id, cancellationToken);
        }
    }
}
