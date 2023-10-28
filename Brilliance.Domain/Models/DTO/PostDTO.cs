using Brilliance.Database.Entities.Base.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brilliance.Domain.Models.DTO
{
    public class PostDTO : IEntity
    {
        public int Id { get; set; }
        public int IdUser { get; set; }

        public int IdCategory { get; set; }

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;
    }
}
