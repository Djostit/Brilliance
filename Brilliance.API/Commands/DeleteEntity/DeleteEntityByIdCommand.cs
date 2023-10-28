using Brilliance.Database.Entities.Base.Interface;

namespace Brilliance.API.Commands.DeleteEntity
{
    internal class DeleteEntityByIdCommand<TBase> : IRequest<Unit>
        where TBase : IEntity
    {
        public int Id { get; }
        public DeleteEntityByIdCommand(int id) => Id = id;
    }
}
