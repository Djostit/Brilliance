using Brilliance.API.Client;
using Brilliance.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Brilliance.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBrilliance _brilliance;
        public HomeController(IBrilliance brilliance)
            => _brilliance = brilliance;
        public async Task<IActionResult> Index()
            => View(await _brilliance.GetPosts(1, 5));

        public IActionResult Privacy()
            => View();

        public IActionResult AccessDenied() 
            => View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
            => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}