using Brilliance.API.Services.Interfaces;
using Brilliance.Database.Entities.Base.Interface;
using Brilliance.Domain.Models.DTO;
using MapsterMapper;

namespace Brilliance.API.Queris.GetEntityById
{
    internal class GetEntityByIdQueryHandler<TModel, TBase> : IRequestHandler<GetEntityByIdQuery<TModel, TBase>, TModel>
        where TModel : IEntity
        where TBase : IEntity
    {
        private readonly IMapper _mapper;
        private readonly IRepository<TBase> _repository;
        public GetEntityByIdQueryHandler(IMapper mapper, IRepository<TBase> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<TModel> Handle(GetEntityByIdQuery<TModel, TBase> request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetById(request.Id, cancellationToken);
            return _mapper.Map<TModel>(entity);
        }
    }

    internal class GetPostByIdQueryHandler : GetEntityByIdQueryHandler<PostDTO, Post>
    {
        public GetPostByIdQueryHandler(IMapper mapper, IRepository<Post> repository) : base(mapper, repository)
        {
        }
    }
}
