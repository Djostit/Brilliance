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
        public async Task<IActionResult> GetPosts(int page = 1, int size = 5, string sort = "asc")
            => Ok(await _mediator.Send(new GetPostsQuery(page, size, sort)));

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPost([FromRoute] int id)
            => Ok(await _mediator.Send(new GetPostByIdQuery(id)));

        [HttpPost]
        public async Task<IActionResult> CreatePost(PostDTO postDTO)
        {
            await _mediator.Send(new AddPostCommand(postDTO.IdUser, postDTO.IdCategory, postDTO.Title, postDTO.Description));
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
