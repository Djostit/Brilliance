namespace Brilliance.API.Commands.DeleteEntity
{
    internal record DeleteCommentCommand(int Id) : IRequest;
    internal class DeleteCommentCommandValidator : AbstractValidator<DeleteCommentCommand>
    {
        public DeleteCommentCommandValidator(ICommentService commentService)
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Обязательно")
                .MustAsync(commentService.IsExists).WithMessage("Такого комментария нет");
        }
    }
    internal class DeteleCommentCommandHandler : IRequestHandler<DeleteCommentCommand>
    {
        private readonly ICommentService _service;
        public DeteleCommentCommandHandler(ICommentService service)
        {
            _service = service;
        }
        public async Task Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            await _service.DeleteComment(request.Id, cancellationToken);
        }
    }
}
