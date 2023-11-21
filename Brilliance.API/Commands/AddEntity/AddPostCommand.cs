namespace Brilliance.API.Commands.AddEntity
{
    internal record AddPostCommand(int IdUser, int IdCategory, string Title, string Description) : IRequest;
    internal class AddPostCommandValidator : AbstractValidator<AddPostCommand>
    {
        public AddPostCommandValidator(IUserService userService, ICategoryService categoryService)
        {
            RuleFor(x => x.IdUser)
                .NotEmpty().WithMessage("Обязательно")
                .MustAsync(userService.IsExists).WithMessage("Пользователь не найден");

            RuleFor(x => x.IdCategory)
                .NotEmpty().WithMessage("Обязательно")
                .MustAsync(categoryService.IsExists).WithMessage("Категория не найдена");

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Обязательно");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Обязательно");
        }
    }
    internal class AddPostCommandHandler : IRequestHandler<AddPostCommand>
    {
        private readonly IPostService _service;
        public AddPostCommandHandler(IPostService service)
        {
            _service = service;
        }
        public async Task Handle(AddPostCommand request, CancellationToken cancellationToken)
        {
            await _service.AddPost(new Post
            {
                IdUser = request.IdUser,
                IdCategory = request.IdCategory,
                Title = request.Title,
                Description = request.Description
            }, cancellationToken);
        }
    }
}
