﻿using Brilliance.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brilliance.Domain.Models.DTO
{
    public class PostDTO
    {
        public int Id { get; set; }

        public int IdUser { get; set; }

        public int IdCategory { get; set; }

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public DateTime Date { get; set; }

        public ICollection<CommentDTO> Comments { get; set; }
    }
}
