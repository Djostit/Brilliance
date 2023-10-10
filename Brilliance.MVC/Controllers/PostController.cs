using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Brilliance.MVC.Controllers
{
    [Authorize]
    public class PostController : Controller
    {
        public IActionResult Posts()
            => View();
    }
}
