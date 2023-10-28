using Brilliance.API.Services.Interfaces;
using Brilliance.Database.Entities.Base.Interface;
using Brilliance.Domain.Models.DTO;
using MapsterMapper;

namespace Brilliance.API.Queris.GetData
{
    internal class GetDataQueryHandler<TModel, TBase> : IRequestHandler<GetDataQuery<TModel, TBase>, List<TModel>>
        where TModel : IEntity
        where TBase : IEntity
    {
        private readonly IMapper _mapper;
        private readonly IRepository<TBase> _repository;
        public GetDataQueryHandler(IMapper mapper, IRepository<TBase> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<List<TModel>> Handle(GetDataQuery<TModel, TBase> request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetAll(cancellationToken);
            return  _mapper.Map<List<TModel>>(data);
        }
    }

    internal class GetUsersQueryHandler : GetDataQueryHandler<UserDTO, User>
    {
        public GetUsersQueryHandler(IMapper mapper, IRepository<User> repository) : base(mapper, repository)
        {
        }
    }
    internal class GetPostsQueryHandler : GetDataQueryHandler<PostDTO, Post>
    {
        public GetPostsQueryHandler(IMapper mapper, IRepository<Post> repository) : base(mapper, repository)
        {
        }
    }
}
