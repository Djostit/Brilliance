using Brilliance.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brilliance.Domain.Models.DTO
{
    public class CommentDTO
    {
        public int Id { get; set; }

        public string Username { get; set; } = null!;

        public string Name { get; set; } = null!;

    }
}
