using Brilliance.Database.Entities.Base.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brilliance.Domain.Models.DTO
{
    public class CategoryDTO : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;
    }
}
