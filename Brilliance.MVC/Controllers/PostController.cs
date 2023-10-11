using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Brilliance.MVC.Controllers
{
    [Authorize]
    public class PostController : Controller
    {
        [Authorize(Roles = "2")]
        public IActionResult Posts()
            => View();
    }
}
