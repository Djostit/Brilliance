using Brilliance.API.Services.Interfaces;
using Brilliance.Domain.Models.DTO;
using MapsterMapper;

namespace Brilliance.API.Commands.AddEntity
{
    internal class AddPostCommandHandler : AddEntityCommandHandler<PostDTO, Post>
    {
        public AddPostCommandHandler(IMapper mapper, IRepository<Post> repository) : base(mapper, repository)
        {
        }
    }
}
