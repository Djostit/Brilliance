using Brilliance.API.Client;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Brilliance.MVC.Controllers
{
    public class PostController : Controller
    {
        private readonly IBrilliance _brilliance;
        public PostController(IBrilliance brilliance)
        {
            _brilliance = brilliance;
        }
        public async Task<IActionResult> Details([FromRoute] int id) 
            => View(await _brilliance.GetPost(id));
        public IActionResult Index()
            => View();
        [Authorize]
        public IActionResult Create()
            => View();

        [Authorize]
        [HttpPost]
        public IActionResult Create(Type type) 
            => Ok();
    }
}
