using Brilliance.API.Services.Interfaces;
using Brilliance.Database.Entities.Base.Interface;

namespace Brilliance.API.Queris.GetPage
{
    internal class GetPageQuery<TModel, TBase> : IRequest<IPage<TModel>>
        where TModel : IEntity
        where TBase : IEntity
    {
        public int Page { get; set; }
        public int Size { get; set; }
    }
}
