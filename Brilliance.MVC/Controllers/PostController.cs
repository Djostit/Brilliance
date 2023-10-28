using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Brilliance.MVC.Controllers
{
    public class PostController : Controller
    {
        public IActionResult Details() 
            => View();
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
