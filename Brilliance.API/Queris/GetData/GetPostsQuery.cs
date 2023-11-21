using Brilliance.Domain.Models;

namespace Brilliance.API.Queris.GetData
{
    internal record GetPostsQuery(int Page, int Size, string Sort) : IRequest<Pagination<Post>>;
    internal class GetPostsQueryValidator : AbstractValidator<GetPostsQuery>
    {
        public GetPostsQueryValidator()
        {
            RuleFor(x => x.Page)
                .NotEmpty();

            RuleFor(x => x.Size)
                .NotEmpty();

            RuleFor(x => x.Sort)
                .NotEmpty();
        }
    }
    internal class GetPostsQueryHandler : IRequestHandler<GetPostsQuery, Pagination<Post>>
    {
        private readonly IPostService _service;
        public GetPostsQueryHandler(IPostService service)
        {
            _service = service;
        }
        public async Task<Pagination<Post>> Handle(GetPostsQuery request, CancellationToken cancellationToken)
        {
            return await _service.GetPosts(request.Page, request.Size, request.Sort, cancellationToken);
        }
    }
}
