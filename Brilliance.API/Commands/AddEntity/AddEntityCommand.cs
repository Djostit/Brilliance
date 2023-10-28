using Brilliance.Database.Entities.Base.Interface;

namespace Brilliance.API.Commands.AddEntity
{
    internal class AddEntityCommand<TModel, TBase> : IRequest<TBase> 
        where TModel : IEntity
        where TBase : IEntity
    {
        public TModel Model { get; set; }
        public AddEntityCommand(TModel model) => Model = model;
    }
}
