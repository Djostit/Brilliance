﻿using Brilliance.Domain.Models;
using Refit;

namespace Brilliance.API.Client
{
    public interface IBrilliance
    {
        [Post("/api/v1/authorization")]
        Task<string> Authorization([Body] UserDTO userDTO);
    }
}