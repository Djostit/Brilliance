using Brilliance.API.Commands.AddEntity;
using Brilliance.API.Commands.DeleteEntity;
using Brilliance.API.Queris.GetEntityById;
using Brilliance.API.Queris.GetPage;
using Brilliance.Domain.Models.DTO;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost]
        public async Task<IActionResult> CreatePost(PostDTO postDTO)
        {
            await _mediator.Send(new AddEntityCommand<PostDTO, Post>(postDTO));
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetPosts(int page, int size)
            => Ok(await _mediator.Send(new GetPageQuery<PostDTO, Post>() { Page = page, Size = size }));

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPost([FromRoute] int id)
            => Ok(await _mediator.Send(new GetEntityByIdQuery<PostDTO, Post>(id)));

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost([FromRoute] int id)
        {
            await _mediator.Send(new DeleteEntityByIdCommand<Post>(id));
            return NoContent();
        }        
        
    }
}
