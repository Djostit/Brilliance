using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brilliance.Domain.Models.Requests
{
    public class CommentRequest
    {
        public int IdUser { get; set; }

        public int IdPost { get; set; }

        public string Name { get; set; } = null!;
    }
}
