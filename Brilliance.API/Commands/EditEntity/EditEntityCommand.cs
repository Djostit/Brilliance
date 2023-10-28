using Brilliance.Database.Entities.Base.Interface;

namespace Brilliance.API.Commands.EditEntity
{
    internal class EditEntityCommand<TModel, TBase> : IRequest<TBase>
        where TModel : IEntity
        where TBase : IEntity
    {
        public TModel Model { get; set; }
        public EditEntityCommand(TModel model) => Model = model;
    }
}
