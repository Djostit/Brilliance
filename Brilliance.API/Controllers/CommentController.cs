using Brilliance.Domain.Models.Requests;

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

        /// <summary>
        /// Создание комментария
        /// </summary>
        /// <param name="commentDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateComment(CommentRequest comment)
        {
            await _mediator.Send(new AddCommentCommand(comment.IdPost, comment.IdUser, comment.Name));
            return CreatedAtAction(null, null, null);
        }

        /// <summary>
        /// Удаление комментария
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment([FromRoute] int id)
        {
            await _mediator.Send(new DeleteCommentCommand(id));
            return NoContent();
        }
    }
}
