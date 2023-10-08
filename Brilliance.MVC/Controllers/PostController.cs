using Microsoft.AspNetCore.Mvc;

namespace Brilliance.MVC.Controllers
{
    public class PostController : Controller
    {
        public IActionResult Posts()
            => View();
    }
}
