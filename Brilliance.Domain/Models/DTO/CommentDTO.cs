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

        public int IdUser { get; set; }

        public int IdPost { get; set; }

        public string Name { get; set; }
    }
}
