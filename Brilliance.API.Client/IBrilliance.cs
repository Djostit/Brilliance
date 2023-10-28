using Brilliance.Domain.Models;
using Brilliance.Domain.Models.DTO;
using Refit;

namespace Brilliance.API.Client
{
    public interface IBrilliance
    {
        [Post("/api/v1/authorization")]
        Task<string> Authorization([Body] UserDTO userDTO);
    }
}
