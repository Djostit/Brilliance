using Brilliance.Database.Entities.Base.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brilliance.Domain.Models.DTO
{
    public class UserDTO : IEntity
    {
        public int Id { get; set; }
        public int IdRole { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
