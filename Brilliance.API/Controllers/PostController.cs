using Brilliance.Domain.Models.Requests;

namespace Brilliance.API.Controllers
{
    [ApiController]
    [Route("api/v1/posts")]
    public class PostController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PostController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetPosts(int page = 1, int size = 5, string sort = "asc", int? categoryId = null)
            => Ok(await _mediator.Send(new GetPostsQuery(page, size, sort, categoryId)));

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPost([FromRoute] int id)
            => Ok(await _mediator.Send(new GetPostByIdQuery(id)));

        [HttpPost]
        public async Task<IActionResult> CreatePost(PostRequest post)
        {
            await _mediator.Send(new AddPostCommand(post.IdUser, post.IdCategory, post.Title, post.Description));
            return CreatedAtAction(null, null, null);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost([FromRoute] int id)
        {
            await _mediator.Send(new DeletePostCommand(id));
            return NoContent();
        }
    }
}
