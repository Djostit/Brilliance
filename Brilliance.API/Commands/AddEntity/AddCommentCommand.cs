namespace Brilliance.API.Commands.AddEntity
{
    internal record AddCommentCommand(int IdPost, int IdUser, string Name) : IRequest;
    internal class AddCommentCommandValidator : AbstractValidator<AddCommentCommand>
    {
        public AddCommentCommandValidator(IPostService postService, IUserService userService)
        {
            RuleFor(x => x.IdPost)
                .NotEmpty().WithMessage("Обязательно")
                .MustAsync(postService.IsExists).WithMessage("Поста нет");
            RuleFor(x => x.IdUser)
                .NotEmpty().WithMessage("Обязательно")
                .MustAsync(userService.IsExists).WithMessage("Пользователя нет");
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Обязательно")
                .MinimumLength(3).WithMessage("Мало")
                .MaximumLength(100).WithMessage("Много");
        }
    }
    internal class AddCommentCommandHandler : IRequestHandler<AddCommentCommand>
    {
        private readonly ICommentService _service;
        public AddCommentCommandHandler(ICommentService service)
        {
            _service = service;
        }
        public async Task Handle(AddCommentCommand request, CancellationToken cancellationToken)
        {
            await _service.AddComment(new Comment
            {
                IdPost = request.IdPost,
                IdUser = request.IdUser,
                Name = request.Name
            }, cancellationToken);
        }
    }
}
