namespace Brilliance.API.Queris.GetEntityById
{
    internal record GetPostByIdQuery(int Id) : IRequest<Post>;
    internal class GetPostByIdQueryValidator : AbstractValidator<GetPostByIdQuery>
    {
        public GetPostByIdQueryValidator(IPostService postService)
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .MustAsync(postService.IsExists);
        }
    }
    internal class GetPostByIdQueryHandler : IRequestHandler<GetPostByIdQuery, Post>
    {
        private readonly IPostService _service;
        public GetPostByIdQueryHandler(IPostService service)
        {
            _service = service;
        }
        public async Task<Post> Handle(GetPostByIdQuery request, CancellationToken cancellationToken)
        {
            return await _service.GetPost(request.Id, cancellationToken);
        }
    }
}
