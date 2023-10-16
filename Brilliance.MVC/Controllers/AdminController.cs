using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Brilliance.MVC.Controllers
{
    [Authorize(Roles = "2")]
    public class AdminController : Controller
    {
        public IActionResult Panel()
            => View();
    }
}
