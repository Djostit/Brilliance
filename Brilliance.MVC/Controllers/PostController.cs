using Brilliance.API.Client;
using Brilliance.Domain.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Brilliance.MVC.Controllers
{
    public class PostController : Controller
    {
        private readonly IPost _post;
        public PostController(IPost post)
            => _post = post;
        public async Task<IActionResult> Details([FromRoute] int id) 
            => View(await _post.GetPost(id));
        public IActionResult Index()
            => View();
        [Authorize]
        public IActionResult Create()
            => View();

        [Authorize]
        [HttpPost]
        public IActionResult Create(PostDTO postDTO) 
            => Ok();
    }
}
