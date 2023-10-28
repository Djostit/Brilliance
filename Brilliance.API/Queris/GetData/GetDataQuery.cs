using Brilliance.Database.Entities.Base.Interface;

namespace Brilliance.API.Queris.GetData
{
    internal class GetDataQuery<TModel, TBase> : IRequest<List<TModel>>
        where TModel : IEntity
        where TBase : IEntity
    {
    }
}
