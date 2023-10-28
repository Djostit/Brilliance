using Brilliance.API.Services.Interfaces;
using Brilliance.Domain.Models.DTO;
using MapsterMapper;

namespace Brilliance.API.Commands.AddEntity
{
    internal class AddCommentCommandHandler : AddEntityCommandHandler<CommentDTO, Comment>
    {
        public AddCommentCommandHandler(IMapper mapper, IRepository<Comment> repository) : base(mapper, repository)
        {
        }
    }
}
