using Brilliance.Database.Entities.Base.Interface;

namespace Brilliance.API.Queris.GetEntityById
{
    internal class GetEntityByIdQuery<TModel, TBase> : IRequest<TModel>
        where TModel : IEntity
        where TBase : IEntity
    {
        public int Id { get; }
        public GetEntityByIdQuery(int id) => Id = id;
    }
}
