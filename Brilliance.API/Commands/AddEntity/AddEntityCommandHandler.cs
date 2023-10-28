using Brilliance.API.Services.Interfaces;
using Brilliance.Database.Entities.Base.Interface;
using MapsterMapper;

namespace Brilliance.API.Commands.AddEntity
{
    internal class AddEntityCommandHandler<TModel, TBase> : IRequestHandler<AddEntityCommand<TModel, TBase>, TBase> 
        where TModel : IEntity
        where TBase : IEntity
    {
        private readonly IMapper _mapper;
        private readonly IRepository<TBase> _repository;
        public AddEntityCommandHandler(IMapper mapper, IRepository<TBase> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<TBase> Handle(AddEntityCommand<TModel, TBase> request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<TBase>(request.Model);
            return await _repository.Add(entity, cancellationToken);
        }
    }
}
