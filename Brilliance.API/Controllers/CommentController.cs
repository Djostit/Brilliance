using Brilliance.API.Commands.AddEntity;
using Brilliance.API.Commands.DeleteEntity;
using Brilliance.Domain.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Brilliance.API.Controllers
{
    [ApiController]
    [Route("api/v1/comment")]
    public class CommentController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CommentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(CommentDTO commentDTO)
        {
            await _mediator.Send(new AddEntityCommand<CommentDTO, Comment>(commentDTO));
            return Ok();
        }
        

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment([FromRoute] int id)
        {
            await _mediator.Send(new DeleteEntityByIdCommand<Comment>(id));
            return NoContent();
        }
    }
}
