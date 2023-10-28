using Brilliance.API.Services.Interfaces;
using Brilliance.Database.Entities.Base.Interface;

namespace Brilliance.API.Commands.DeleteEntity
{
    internal class DeleteEntityByIdCommandHandler<TBase> : IRequestHandler<DeleteEntityByIdCommand<TBase>, Unit>
        where TBase : IEntity
    {
        private readonly IRepository<TBase> _repository;
        public DeleteEntityByIdCommandHandler(IRepository<TBase> repository) => _repository = repository;
        public async Task<Unit> Handle(DeleteEntityByIdCommand<TBase> request, CancellationToken cancellationToken)
        {
            await _repository.DeleteById(request.Id, cancellationToken);
            return Unit.Value;
        }
    }
}
