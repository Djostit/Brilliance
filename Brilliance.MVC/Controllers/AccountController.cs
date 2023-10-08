using Microsoft.AspNetCore.Mvc;

namespace Brilliance.MVC.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult SignUp()
            => View();
        public IActionResult SignIn()
            => View();
        public IActionResult Profile()
            => View();
    }
}
