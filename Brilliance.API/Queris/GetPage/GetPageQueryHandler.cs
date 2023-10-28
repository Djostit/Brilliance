using Brilliance.API.Services.Interfaces;
using Brilliance.Database.Entities.Base.Interface;
using Brilliance.Domain.Models.DTO;
using MapsterMapper;

namespace Brilliance.API.Queris.GetPage
{
    internal class GetPageQueryHandler<TModel, TBase> : IRequestHandler<GetPageQuery<TModel, TBase>, IPage<TModel>>
        where TModel : IEntity
        where TBase : IEntity
    {
        private readonly IRepository<TBase> _repository;
        private readonly IMapper _mapper;
        public GetPageQueryHandler(IRepository<TBase> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IPage<TModel>> Handle(GetPageQuery<TModel, TBase> request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetPage(request.Page, request.Size, cancellationToken);
            return _mapper.Map<IPage<TModel>>(data);
        }
    }
    internal class GetPostsQueryHandler : GetPageQueryHandler<PostDTO, Post>
    {
        public GetPostsQueryHandler(IRepository<Post> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
