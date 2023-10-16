using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Brilliance.MVC.Controllers
{
    public class PostController : Controller
    {
        public IActionResult Post() 
            => View();
        public IActionResult Posts()
            => View();
        [Authorize]
        public IActionResult Add()
            => View();

        [Authorize]
        [HttpPost()]
        public IActionResult Add(Type type) 
            => Ok();
    }
}
