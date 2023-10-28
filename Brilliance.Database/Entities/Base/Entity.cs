using Brilliance.Database.Entities.Base.Interface;
using System.ComponentModel.DataAnnotations;

namespace Brilliance.Database.Entities.Base
{
    public abstract class Entity : IEntity
    {
        public int Id { get; set; }
    }
}
